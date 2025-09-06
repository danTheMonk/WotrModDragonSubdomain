using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using WotrModDragonSubdomain.DragonBreath.Acid;
using WotrModDragonSubdomain.DragonBreath.Cold;
using WotrModDragonSubdomain.DragonBreath.Electricity;
using WotrModDragonSubdomain.DragonBreath.Fire;

namespace WotrModDragonSubdomain
{
    public class DragonSubdomainBreathWeaponFeatureSelection
    {
        public static readonly string FeatureSelectionName = "DragonSubdomainBreathWeaponFeatureSelection";
        public static readonly string FeatureSelectionGuid = "C3D4E5F6-A1B2-3456-7890-1234567890AB"; // Unique GUID

        public static void Configure()
        {
            var dragonSubdomainBreathWeaponFeatureSelection = FeatureSelectionConfigurator
                .New(FeatureSelectionName, FeatureSelectionGuid)
                .SetDisplayName("DragonSubdomain.BreathWeapon.FeatureSelection.Name")
                .SetDescription("DragonSubdomain.BreathWeapon.FeatureSelection.Description")
                .SetIcon(Constants.dragonBreathFeatureReference.Get().m_Icon) // Use the same icon as the dragon breath feature
                .SetAllFeatures([
                    AcidDragonBreathFeature.FeatureName,
                    ColdDragonBreathFeature.FeatureName,
                    ElectricityDragonBreathFeature.FeatureName,
                    FireDragonBreathFeature.FeatureName
                ])
                .SetIsClassFeature(true)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .Configure();
        }
    }
}
