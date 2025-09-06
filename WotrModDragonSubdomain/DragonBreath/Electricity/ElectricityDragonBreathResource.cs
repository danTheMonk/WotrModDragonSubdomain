using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.DragonBreath.Electricity
{
    public class ElectricityDragonBreathResource
    {
        public static readonly string ResourceName = "ElectricityDragonBreathResource";
        public static readonly string ResourceGuid = "60ef43fe-ce17-4fde-835c-c0a2c2d36a31";

        public static void Configure()
        {
            var electricityDragonBreathResource = AbilityResourceConfigurator
                .New(ResourceName, ResourceGuid) // Unique GUID
                .SetMaxAmount(ResourceAmountBuilder
                    .New(1)
                    .IncreaseByLevelStartPlusDivStep(
                        classes: [CharacterClassRefs.ClericClass.ToString()],
                        otherClassLevelsMultiplier: 0,
                        startingLevel: 4,
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
