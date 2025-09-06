using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotrModDragonSubdomain
{
    public class DragonSubdomainSpellListFeature
    {
        public static readonly string FeatureName = "DragonSubdomainSpellListFeature";
        public static readonly string FeatureGuid = "E3F7A9C2-4D5B-6E8F-9A1B-2C3D4E5F6789";

        public static void Configure()
        {
            var dragonSubdomainSpellListFeature = FeatureConfigurator
                .New(FeatureName, FeatureGuid, [])
                .AddSpecialSpellList(characterClass: CharacterClassRefs.ClericClass.ToString(), spellList: DragonSubdomainSpellList.SpellListName)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
