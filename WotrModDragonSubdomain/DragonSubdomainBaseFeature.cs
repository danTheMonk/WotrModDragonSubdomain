using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain
{
    public class DragonSubdomainBaseFeature
    {
        public static readonly string FeatureName = "DragonSubdomainBaseFeature";
        public static readonly string FeatureGuid = "662ba500-1dfe-4fe7-9279-6ffb701c9c20"; // Unique GUID

        public static void Configure()
        {
            var dragonSubdomainBaseFeature = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .CopyFrom(FeatureRefs.ScalykindDomainBaseFeature.Reference)
                // .RemoveComponents(c => c is AddFeatureOnClassLevel) // May need to make this more exact if it ends up removing the line below too
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
