using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Fire
{
    public class FireDragonBreathFeatureSeparatist
    {
        public static readonly string FeatureName = "FireDragonBreathFeatureSeparatist";
        public static readonly string FeatureGuid = "32DCA252-0D73-4CE1-81D1-FFD56AF755EA"; // Unique GUID

        public static void Configure()
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIGoldBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            _ = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgression.Separatist.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Separatist.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([FireDragonBreathAbilitySeparatist.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: FireDragonBreathResourceSeparatist.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [FireDragonBreathAbilitySeparatist.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
