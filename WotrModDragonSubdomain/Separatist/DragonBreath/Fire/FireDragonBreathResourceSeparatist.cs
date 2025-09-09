using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Fire
{
    public class FireDragonBreathResourceSeparatist
    {
        public static readonly string ResourceName = "FireDragonBreathResourceSeparatist";
        public static readonly string ResourceGuid = "CEEC41E5-1D24-4F9B-A10D-35352B885A9F";

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
