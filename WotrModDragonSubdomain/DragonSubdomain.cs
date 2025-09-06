using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;

namespace WotrModDragonSubdomain
{
    public class DragonSubdomain
    {
        public static readonly string DomainName = "DragonSubdomain";
        public static readonly string DomainGuid = "5ce8b851-8878-46a8-b951-910e29fc532d";

        public static readonly string ProgressionName = "DragonSubdomainProgression";
        public static readonly string ProgressionGuid = "09babed0-cf38-4eae-b09a-0e630edbe546";

        public static void Configure()
        {
            // Reference the Scalykind domain progression blueprint
            var apsuFeature = FeatureRefs.ApsuFeature.Reference; // Reference to a deity feature, adjust as needed
            var dahakFeature = FeatureRefs.DahakFeature.Reference; // Reference to another deity feature, adjust as needed

            // Create a new progression for the Dragon subdomain
            var dragonSubdomainProgression = ProgressionConfigurator
                .New(ProgressionName, ProgressionGuid)
                .SetDisplayName("DragonSubdomainProgression.Name")
                .SetDescription("DragonSubdomainProgression.Description")
                .AddPrerequisiteFeature(
                    feature: FeatureRefs.ScalykindDomainAllowed.ToString(),
                    isFeatureSelectionWhiteList: false,
                    checkInProgression: false,
                    group: Prerequisite.GroupType.All,
                    hideInUI: true)
                .AddPrerequisiteNoArchetype(
                    archetype: ArchetypeRefs.SacredHuntsmasterArchetype.ToString(),
                    characterClass: CharacterClassRefs.InquisitorClass.ToString(),
                    checkInProgression: false,
                    group: Prerequisite.GroupType.All,
                    hideInUI: false,
                    isFeatureSelectionWhiteList: false)
                .AddLearnSpellList(
                    characterClass: CharacterClassRefs.ClericClass.ToString(),
                    archetype: ArchetypeRefs.EcclesitheurgeArchetype.ToString(),
                    spellList: DragonSubdomainSpellList.SpellListName)
                //.AddPrerequisiteNoFeature(
                //    feature: DragonSubdomainProgressionSecondary.ProgressionName,
                //    group: Prerequisite.GroupType.All,
                //    checkInProgression: false,
                //    hideInUI: true,
                //    isFeatureSelectionWhiteList: true)
                .AddLearnSpellList(
                    archetype: ArchetypeRefs.DivineHunterArchetype_0.ToString(),
                    characterClass: CharacterClassRefs.HunterClass.ToString(),
                    spellList: DragonSubdomainSpellList.SpellListName)
                .AddPrerequisiteNoFeature(
                    feature: ProgressionRefs.ScalykindDomainProgressionSeparatist.ToString(),
                    group: Prerequisite.GroupType.All,
                    checkInProgression: false,
                    hideInUI: true,
                    isFeatureSelectionWhiteList: true)
                .SetGroups(FeatureGroup.Domain)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(true)
                .SetClasses([
                    CharacterClassRefs.ClericClass.ToString(),
                    CharacterClassRefs.InquisitorClass.ToString(),
                    CharacterClassRefs.HunterClass.ToString(),
                    CharacterClassRefs.ArcanistClass.ToString()
                ])
                .SetArchetypes([
                    new BlueprintProgression.ArchetypeWithLevel {
                        AdditionalLevel = -2,
                        m_Archetype = ArchetypeRefs.DivineHunterArchetype_0.Cast<BlueprintArchetypeReference>().Reference
                    }, new BlueprintProgression.ArchetypeWithLevel {
                        AdditionalLevel = 0,
                        m_Archetype = ArchetypeRefs.MagicDeceiver.Cast<BlueprintArchetypeReference>().Reference
                    }
                ])
                .SetForAllOtherClasses(false)
                .AddToLevelEntry(1, DragonSubdomainBaseFeature.FeatureName)
                .AddToLevelEntry(4, DragonSubdomainBreathWeaponFeatureSelection.FeatureSelectionName) // Replace with feature selection
                .AddToUIGroups([FeatureRefs.ScalykindDomainBaseFeature.ToString(), DragonSubdomainBreathWeaponFeatureSelection.FeatureSelectionName])
                .SetGiveFeaturesForPreviousLevels(true)
                .SetFeaturesRankIncrease([FeatureRefs.TricksterLoreReligionScalykindDomainRankFeature.ToString()])
                .Configure();

            var addDragonSubdomainToDomainsFeatureSelection = FeatureSelectionConfigurator
                .For(FeatureSelectionRefs.DomainsSelection)
                .AddToAllFeatures(dragonSubdomainProgression)
                .SetDisplayName("DragonSubdomainProgression.Name")
                .SetDescription("DragonSubdomainProgression.Description")
                .Configure();

            var addDragonSubdomainToDivineHunterDomainsFeatureSelection = FeatureSelectionConfigurator
                .For(FeatureSelectionRefs.DivineHunterDomainsSelection)
                .AddToAllFeatures(dragonSubdomainProgression)
                .SetDisplayName("DragonSubdomainProgression.Name")
                .SetDescription("DragonSubdomainProgression.Description")
                .Configure();

            var addDragonSubdomainToSecondDomainsSeparatistFeatureSelection = FeatureSelectionConfigurator
                .For(FeatureSelectionRefs.SecondDomainsSeparatistSelection)
                .AddToAllFeatures(dragonSubdomainProgression)
                .SetDisplayName("DragonSubdomainProgression.Name")
                .SetDescription("DragonSubdomainProgression.Description")
                .Configure();

            //var dragonSubdomainAllowed = FeatureConfigurator
            //    .New("DragonSubdomainAllowed", "F2A1B3C4-D5E6-7890-1234-56789ABCDEF0")
            //    .AddSpecialSpellListForArchetype(
            //        archetype: ArchetypeRefs.EcclesitheurgeArchetype.ToString(),
            //        characterClass: CharacterClassRefs.ClericClass.ToString(),
            //        spellList: DragonSubdomainSpellList.SpellListName)
            //    .SetAllowNonContextActions(false)
            //    .SetHideInUI(true)
            //    .SetHideInCharacterSheetAndLevelUp(false)
            //    .SetHideNotAvailibleInUI(false)
            //    .SetRanks(1)
            //    .SetReapplyOnLevelUp(false)
            //    .SetIsClassFeature(true)
            //    .SetIsPrerequisiteFor([
            //        FeatureRefs.ScalykindBlessingFeature.ToString(),
            //        dragonSubdomainProgression,
            //        DragonSubdomainProgressionSecondary.ProgressionName
            //    ])
            //    .Configure();
        }
    }
}
