using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Electricity
{
    public class ElectricityDragonBreathFeatureSeparatist
    {
        public static readonly string FeatureName = "ElectricityDragonBreathFeatureSeparatist";
        public static readonly string FeatureGuid = "5C5E4DB3-F33D-42B3-9A6C-4FC6FB493D70"; // Unique GUID  

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIBlueBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            _ = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgression.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([ElectricityDragonBreathAbilitySeparatist.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: ElectricityDragonBreathResourceSeparatist.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [ElectricityDragonBreathAbilitySeparatist.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
