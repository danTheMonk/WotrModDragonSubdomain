using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotrModDragonSubdomain.DragonBreath.Fire
{
    public class FireDragonBreathResource
    {
        public static readonly string ResourceName = "FireDragonBreathResource";
        public static readonly string ResourceGuid = "ac305041-dbe6-43cd-bf43-efea240fa4d2";

        public static void Configure()
        {
            var fireDragonBreathResource = AbilityResourceConfigurator
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
