using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WotrModDragonSubdomain.DragonBreath.Cold
{
    public class ColdDragonBreathAbility
    {
        public static readonly string AbilityName = "ColdDragonBreathAbility";
        public static readonly string AbilityGuid = "b1c2d3e4-f5a6-7890-1234-56789abcdef1"; // Unique GUID

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var coldDragonBreathAttack = ActionsBuilder
                .New()
                .SavingThrow(
                    SavingThrowType.Reflex,
                    onResult: ActionsBuilder.New() // TODO: Add Custom DC if needed
                        .DealDamage(
                            DamageTypes.Energy(DamageEnergyType.Cold),
                            ContextDice.Value(DiceType.D6, ContextValues.Rank()),
                            halfIfSaved: true));

            var coldDragonBreathAbility = AbilityConfigurator
                .New(AbilityName, AbilityGuid) // Unique GUID
                .SetDisplayName("DragonSubdomain.DomainProgression.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath ability
                .SetLocalizedSavingThrow(SavingThrow.ReflexHalf)
                .SetRange(AbilityRange.Projectile)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.BreathWeapon)
                .SetActionType(CommandType.Standard)
                .SetSpellResistance()
                .SetIsDomainAbility(true)
                .AllowTargeting(enemies: true, point: true)
                .SetShouldTurnToTarget(true)
                .AddAbilityDeliverProjectile(type: AbilityProjectileType.Cone, projectiles: [ProjectileRefs.ColdCone15Feet00.ToString()], length: 15.Feet())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.ClericClass.ToString()]).WithCustomProgression((3, 0), (5, 3), (7, 4), (9, 5), (11, 6), (13, 7), (15, 8), (17, 9), (19, 10), (20, 11))) // ([Round down (Lvl / 2)] + 1)d6
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: ColdDragonBreathResource.ResourceName)
                .AddAbilityEffectRunAction(coldDragonBreathAttack)
                .AddAbilityCasterHasNoFacts([dragonBreathAbility.ToString()]) // Prevent stacking with existing breath weapon
                .Configure();
        }
    }
}
