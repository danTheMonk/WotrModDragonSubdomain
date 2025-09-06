using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.DragonBreath.Cold
{
    public class ColdDragonBreathResource
    {
        public static readonly string ResourceName = "ColdDragonBreathResource";
        public static readonly string ResourceGuid = "2e623ba0-1ef8-48ee-bed9-c9c030e4fa0c";

        public static void Configure()
        {
            var coldDragonBreathResource = AbilityResourceConfigurator
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
