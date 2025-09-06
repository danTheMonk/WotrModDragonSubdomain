using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace WotrModDragonSubdomain.DragonBreath.Electricity
{
    public class ElectricityDragonBreathFeature
    {
        public static readonly string FeatureName = "ElectricityDragonBreathFeature";
        public static readonly string FeatureGuid = "7648df39-55ca-4130-841e-b8955efa28be"; // Unique GUID  

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIBlueBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var electricityDragonBreathFeature = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgressionFeature.Name")
                .SetDescription("DragonSubdomain.DomainProgressionFeature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([ElectricityDragonBreathAbility.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: ElectricityDragonBreathResource.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [ElectricityDragonBreathAbility.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
