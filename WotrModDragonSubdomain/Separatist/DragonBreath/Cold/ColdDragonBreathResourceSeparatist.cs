using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain.Separatist.DragonBreath.Cold
{
    public class ColdDragonBreathResourceSeparatist
    {
        public static readonly string ResourceName = "ColdDragonBreathResourceSeparatist";
        public static readonly string ResourceGuid = "94BD956C-20C2-407B-AC64-EB932C74DBE7";

        public static void Configure()
        {
            _ = AbilityResourceConfigurator
                .New(ResourceName, ResourceGuid)
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
