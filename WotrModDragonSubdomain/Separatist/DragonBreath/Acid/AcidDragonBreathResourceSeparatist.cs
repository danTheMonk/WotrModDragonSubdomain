using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Acid
{
    public class AcidDragonBreathResourceSeparatist
    {
        public static readonly string ResourceName = "AcidDragonBreathResourceSeparatist";
        public static readonly string ResourceGuid = "0A72ACA3-C440-41E7-A2EB-94F52B5A0870";

        public static void Configure()
        {
            _ = AbilityResourceConfigurator
                .New(ResourceName, ResourceGuid) // Unique GUID
                .SetMaxAmount(ResourceAmountBuilder
                    .New(1)
                    .IncreaseByLevelStartPlusDivStep(
                        classes: [CharacterClassRefs.ClericClass.ToString()],
                        otherClassLevelsMultiplier: 0,
                        startingLevel: 6,
                        startingBonus: 0,
                        levelsPerStep: 5,
                        bonusPerStep: 1
                    )
                )
                .SetUseMax()
                .SetMax(3)
                .SetIsDomainAbility(true)
                .Configure();
        }
    }
}
