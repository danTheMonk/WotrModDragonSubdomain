using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using WotrModDragonSubdomain.Separatist.DragonBreath.Acid;
using WotrModDragonSubdomain.Separatist.DragonBreath.Cold;
using WotrModDragonSubdomain.Separatist.DragonBreath.Electricity;
using WotrModDragonSubdomain.Separatist.DragonBreath.Fire;

namespace WotrModDragonSubdomain.Separatist
{
    public class DragonSubdomainBreathWeaponFeatureSelectionSeparatist
    {
        public static readonly string FeatureSelectionName = "DragonSubdomainBreathWeaponFeatureSelectionSeparatist";
        public static readonly string FeatureSelectionGuid = "267DDBA7-D0FA-4D3E-9BF7-AF9C3BE9B62E"; // Unique GUID

        public static void Configure()
        {
            _ = FeatureSelectionConfigurator
                .New(FeatureSelectionName, FeatureSelectionGuid)
                .SetDisplayName("DragonSubdomain.BreathWeapon.Separatist.FeatureSelection.Name")
                .SetDescription("DragonSubdomain.BreathWeapon.Separatist.FeatureSelection.Description")
                .SetIcon(Constants.dragonBreathFeatureReference.Get().m_Icon) // Use the same icon as the dragon breath feature
                .SetAllFeatures([
                    AcidDragonBreathFeatureSeparatist.FeatureName,
                    ColdDragonBreathFeatureSeparatist.FeatureName,
                    ElectricityDragonBreathFeatureSeparatist.FeatureName,
                    FireDragonBreathFeatureSeparatist.FeatureName
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
