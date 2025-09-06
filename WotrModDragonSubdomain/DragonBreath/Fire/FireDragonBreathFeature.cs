using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using WotrModDragonSubdomain.DragonBreath.Electricity;

namespace WotrModDragonSubdomain.DragonBreath.Fire
{
    public class FireDragonBreathFeature
    {
        public static readonly string FeatureName = "FireDragonBreathFeature";
        public static readonly string FeatureGuid = "c2d3e4f5-a6b7-8901-2345-6789abcdef12"; // Unique GUID

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIGoldBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var fireDragonBreathFeature = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgressionFeature.Name")
                .SetDescription("DragonSubdomain.DomainProgressionFeature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([FireDragonBreathAbility.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: FireDragonBreathResource.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [FireDragonBreathAbility.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
