using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Electricity
{
    public class ElectricityDragonBreathResourceSeparatist
    {
        public static readonly string ResourceName = "ElectricityDragonBreathResourceSeparatist";
        public static readonly string ResourceGuid = "530ED184-9BCE-4D4E-A649-2F4DFBFB091E";

        public static void Configure()
        {
            var electricityDragonBreathResourceSeparatist = AbilityResourceConfigurator
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
