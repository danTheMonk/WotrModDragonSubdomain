using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WotrModDragonSubdomain
{
    public class DragonSubdomain
    {
        public static readonly string DomainName = "DragonSubdomain";
        public static readonly string DomainGuid = "5CE8B851-8878-46A8-B951-910E29FC532D";

        public static void Configure()
        {
            // Reference the Scalykind domain progression blueprint
            BlueprintProgression scalykindDomain = ProgressionRefs.ScalykindDomainProgression.Reference;
            var dragonBreathFeature = FeatureRefs.BloodlineDraconicBlackBreathWeaponFeature.Reference; // Still need to add actual breath feature or create one if needed
            var animalCompanionFeature = FeatureSelectionRefs.ScalykindCompanionSelectionDomain.Reference; // Reference to animal companion feature, adjust as needed
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIBlackBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var apsuFeature = FeatureRefs.ApsuFeature.Reference; // Reference to a deity feature, adjust as needed
            var dahakFeature = FeatureRefs.DahakFeature.Reference; // Reference to another deity feature, adjust as needed

            var customAcidDragonBreathAttack = ActionsBuilder
                .New()
                .SavingThrow(
                    SavingThrowType.Reflex,
                    onResult: ActionsBuilder.New() // TODO: Add Custom DC if needed
                        .DealDamage(
                            DamageTypes.Energy(DamageEnergyType.Acid),
                            ContextDice.Value(DiceType.D6, ContextValues.Rank()),
                            halfIfSaved: true));

            var customDragonBreathResource = AbilityResourceConfigurator
                .New("CustomDragonBreathResource", "F1E2D3C4-B5A6-7890-1234-56789ABCDEF0") // Unique GUID
                .SetMaxAmount(ResourceAmountBuilder.New(1).IncreaseByLevelStartPlusDivStep([CharacterClassRefs.ClericClass.ToString()], 0, 4, 0, 5, 1))
                .SetUseMax()
                .SetMax(3)
                .SetIsDomainAbility(true)
                .Configure();

            var customAcidDragonBreathAbility = AbilityConfigurator
                .New("CustomBlackDragonBreathAbility", "A1B2C3D4-E5F6-7890-1234-56789ABCDEF0") // Unique GUID
                .SetDisplayName("DragonSubdomain.DomainProgressionFeature.Name")
                .SetDescription("DragonSubdomain.DomainProgressionFeature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath ability
                .SetLocalizedSavingThrow(SavingThrow.ReflexHalf)
                .SetRange(AbilityRange.Projectile)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.BreathWeapon)
                .SetActionType(CommandType.Standard)
                .SetSpellResistance()
                .SetIsDomainAbility(true)
                .AllowTargeting(enemies: true, point: true)
                .SetShouldTurnToTarget(true)
                .AddAbilityDeliverProjectile(type: AbilityProjectileType.Cone, projectiles: [ProjectileRefs.AcidCone15Feet00.ToString()], length: 15.Feet())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.ClericClass.ToString()]).WithCustomProgression((3, 0), (5, 3), (7, 4), (9, 5), (11, 6), (13, 7), (15, 8), (17, 9), (19, 10), (20, 11))) // ([Round down (Lvl / 2)] + 1)d6
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: customDragonBreathResource)
                .AddAbilityEffectRunAction(customAcidDragonBreathAttack)
                .AddAbilityCasterHasNoFacts([dragonBreathAbility.ToString()]) // Prevent stacking with existing breath weapon
                .Configure();

            var customAcidDragonBreathFeature = FeatureConfigurator
                .New("CustomBlackDragonBreathFeature", "D4E6F8B2-3C1A-4F5D-9B8E-1234567890AB")
                .SetDisplayName("DragonSubdomain.DomainProgressionFeature.Name")
                .SetDescription("DragonSubdomain.DomainProgressionFeature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([customAcidDragonBreathAbility.ToString()]) // Put breath weapon ability here
                .AddAbilityResources(resource: customDragonBreathResource.ToString(), restoreAmount: true)
                .Configure();

            var dragonSubdomainSpellList = SpellListConfigurator
                .New("DragonSubdomainSpellList", "B7C9D8E1-F2A3-4567-89AB-CDEF01234567")
                .CopyFrom(SpellListRefs.ScalykindDomainSpellList)
                .Configure();

            // Create a new progression for the Dragon subdomain
            var dragonSubdomain = ProgressionConfigurator
                .New(DomainName, DomainGuid)
                .CopyFrom(scalykindDomain)
                .SetDisplayName("DragonSubdomain.Name")
                .SetDescription("DragonSubdomain.Description")
                .AddPrerequisiteFeature(FeatureRefs.ScalykindDomainAllowed.ToString(), hideInUI: true) // Ensure the Scalykind domain is a prerequisite
                .AddToLevelEntry(4, customAcidDragonBreathFeature.ToString())
                .RemoveFromLevelEntries(4, animalCompanionFeature.ToString())
                .AddSpecialSpellList(characterClass: CharacterClassRefs.ClericClass.ToString(), spellList: dragonSubdomainSpellList)
                .Configure();

            var featureSelection = FeatureSelectionConfigurator
                .For(FeatureSelectionRefs.DomainsSelection)
                .AddToAllFeatures(dragonSubdomain)
                .SetDisplayName("DragonSubdomain.Name")
                .SetDescription("DragonSubdomain.Description")
                .SetGroup(FeatureGroup.Domain)
                .Configure();

            // Need to create a progression for choosing between fire/electric/acid/cold
        }
    }
}
