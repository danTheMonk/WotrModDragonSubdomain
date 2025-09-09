using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Fire
{
    public class FireDragonBreathAbilitySeparatist
    {
        public static readonly string AbilityName = "FireDragonBreathAbilitySeparatist";
        public static readonly string AbilityGuid = "F8AC5B58-D74C-47E5-94AF-66C7AB5FEF82"; // Unique GUID

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIGoldBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var fireDragonBreathAttackSeparatist = ActionsBuilder
                .New()
                .SavingThrow(
                    SavingThrowType.Reflex,
                    onResult: ActionsBuilder.New()
                        .DealDamage(
                            DamageTypes.Energy(DamageEnergyType.Fire),
                            ContextDice.Value(DiceType.D6, ContextValues.Rank()),
                            halfIfSaved: true));

            _ = AbilityConfigurator
                .New(AbilityName, AbilityGuid) // Unique GUID
                .SetDisplayName("DragonSubdomain.DomainProgression.Separatist.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Separatist.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath ability
                .SetLocalizedSavingThrow(SavingThrow.ReflexHalf)
                .SetRange(AbilityRange.Projectile)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.BreathWeapon)
                .SetActionType(CommandType.Standard)
                .SetSpellResistance()
                .SetIsDomainAbility(true)
                .AllowTargeting(enemies: true, point: true)
                .SetShouldTurnToTarget(true)
                .AddAbilityDeliverProjectile(type: AbilityProjectileType.Cone, projectiles: [ProjectileRefs.FireCone15Feet00.ToString()], length: 15.Feet())
                .AddComponent<ContextSetAbilityParams>(c =>
                {
                    c.Add10ToDC = false;
                    c.DC = new ContextValue
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                        Property = UnitProperty.None,
                        m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(UnitPropertyRefs.SeparatistDCProperty.ToString()),
                        m_AbilityParameter = AbilityParameterType.Level,
                        PropertyName = ContextPropertyName.Value1
                    };
                    c.CasterLevel = new ContextValue
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                        Property = UnitProperty.None,
                        m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(UnitPropertyRefs.SeparatistCasterLevelPropery.ToString()),
                        m_AbilityParameter = AbilityParameterType.Level,
                        PropertyName = ContextPropertyName.Value1
                    };
                    c.Concentration = new ContextValue
                    {
                        ValueType = ContextValueType.Simple,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        Property = UnitProperty.None,
                        m_CustomProperty = null,
                        m_AbilityParameter = AbilityParameterType.Level,
                        PropertyName = ContextPropertyName.Value1
                    };
                    c.SpellLevel = new ContextValue
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                        Property = UnitProperty.None,
                        m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(UnitPropertyRefs.SeparatistSpellLevelPropery.ToString()),
                        m_AbilityParameter = AbilityParameterType.Level,
                        PropertyName = ContextPropertyName.Value1
                    };
                })
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.ClericClass.ToString()]).WithCustomProgression((5, 0), (7, 3), (9, 4), (11, 5), (13, 6), (15, 7), (17, 8), (19, 9), (20, 10)))
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: FireDragonBreathResourceSeparatist.ResourceName)
                .AddAbilityEffectRunAction(fireDragonBreathAttackSeparatist)
                .AddAbilityCasterHasNoFacts([dragonBreathAbility.ToString()]) // Prevent stacking with existing breath weapon
                .Configure();
        }
    }
}
