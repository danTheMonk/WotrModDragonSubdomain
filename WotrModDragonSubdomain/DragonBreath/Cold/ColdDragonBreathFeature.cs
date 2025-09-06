using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.DragonBreath.Cold
{
    public class ColdDragonBreathFeature
    {
        public static readonly string FeatureName = "ColdDragonBreathFeature";
        public static readonly string FeatureGuid = "2ae9363d-5d30-4b43-b0e2-f84a0a8ee073";

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var coldDragonBreathFeature = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgressionFeature.Name")
                .SetDescription("DragonSubdomain.DomainProgressionFeature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([ColdDragonBreathAbility.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: ColdDragonBreathResource.ResourceName, restoreAmount: true)
                .Configure();
        }
    }
}
