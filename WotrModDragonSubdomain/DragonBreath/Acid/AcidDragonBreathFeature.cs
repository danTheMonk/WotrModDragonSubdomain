using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace WotrModDragonSubdomain.DragonBreath.Acid
{
    public class AcidDragonBreathFeature
    {
        public static readonly string FeatureName = "AcidDragonBreathFeature";
        public static readonly string FeatureGuid = "d4e6f8b2-3c1a-4f5d-9b8e-1234567890ab"; // Unique GUID

        public static void Configure() 
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIBlackBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            _ = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgression.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([AcidDragonBreathAbility.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: AcidDragonBreathResource.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [AcidDragonBreathAbility.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
