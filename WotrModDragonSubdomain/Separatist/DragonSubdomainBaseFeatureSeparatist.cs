using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.Separatist
{
    public class DragonSubdomainBaseFeatureSeparatist
    {
        public static readonly string FeatureName = "DragonSubdomainBaseFeatureSeparatist";
        public static readonly string FeatureGuid = "2460969A-E5D8-443C-A86E-55B509971EFB"; // Unique GUID

        public static void Configure()
        {
            _ = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .CopyFrom(FeatureRefs.ScalykindDomainBaseFeatureSeparatist.Reference)
                .AddFeatureOnClassLevel(
                    clazz: CharacterClassRefs.ClericClass.ToString(),
                    level: 1,
                    feature: DragonSubdomainSpellListFeature.FeatureName,
                    beforeThisLevel: false)
                .SetIcon(Constants.dragonBreathFeatureReference.Get().m_Icon) // Use the same icon as the dragon breath feature
                .Configure();
        }
    }
}