using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Cold
{
    public class ColdDragonBreathFeatureSeparatist
    {
        public static readonly string FeatureName = "ColdDragonBreathFeatureSeparatist";
        public static readonly string FeatureGuid = "DCE33DF8-41EC-43DC-ABBC-BFEE2D7C488A";

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            var coldDragonBreathFeatureSeparatist = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgression.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([ColdDragonBreathAbilitySeparatist.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: ColdDragonBreathResourceSeparatist.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [ColdDragonBreathAbilitySeparatist.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
