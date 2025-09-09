using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Acid
{
    public class AcidDragonBreathFeatureSeparatist
    {
        public static readonly string FeatureName = "AcidDragonBreathFeatureSeparatist";
        public static readonly string FeatureGuid = "31C08AAF-F31B-4480-9D25-94DD5439FF42"; // Unique GUID

        public static void Configure() 
        {
            var dragonBreathAbility = AbilityRefs.FormOfTheDragonIBlackBreathWeaponAbility.Reference; // Reference to dragon breath ability, adjust as needed

            _ = FeatureConfigurator
                .New(FeatureName, FeatureGuid)
                .SetDisplayName("DragonSubdomain.DomainProgression.Separatist.Feature.Name")
                .SetDescription("DragonSubdomain.DomainProgression.Separatist.Feature.Description")
                .SetIcon(dragonBreathAbility.Get().m_Icon) // Use the same icon as the dragon breath feature
                .AddFacts([AcidDragonBreathAbilitySeparatist.AbilityName]) // Put breath weapon ability here
                .AddAbilityResources(resource: AcidDragonBreathResourceSeparatist.ResourceName, restoreAmount: true)
                .AddReplaceAbilitiesStat(ability: [AcidDragonBreathAbilitySeparatist.AbilityName], stat: StatType.Wisdom) // Replace with Wisdom for DC calculation
                .Configure();
        }
    }
}
