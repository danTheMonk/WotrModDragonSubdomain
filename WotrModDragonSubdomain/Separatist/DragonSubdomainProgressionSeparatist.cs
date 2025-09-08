using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;

namespace WotrModDragonSubdomain.Separatist
{
    public class DragonSubdomainProgressionSeparatist
    {
        public static readonly string ProgressionName = "DragonSubdomainProgressionSeparatist";
        public static readonly string ProgressionGuid = "ACCC978C-7A5C-48F8-B4A6-4D86F073BC4E"; // Unique GUID

        public static void Configure()
        {
            var dragonSubdomainProgressionSeparatist = ProgressionConfigurator
                .New(ProgressionName, ProgressionGuid)
                .SetDisplayName("DragonSubdomain.Progression.Name")
                .SetDescription("DragonSubdomain.Progression.Description")
                .AddPrerequisiteFeature(
                    feature: FeatureRefs.ScalykindDomainAllowedSeparatist.ToString(),
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
                .AddLearnSpellList(
                    archetype: ArchetypeRefs.DivineHunterArchetype_0.ToString(),
                    characterClass: CharacterClassRefs.HunterClass.ToString(),
                    spellList: DragonSubdomainSpellList.SpellListName)
                .AddPrerequisiteNoFeature(
                    feature: ProgressionRefs.ScalykindDomainProgression.ToString(),
                    group: Prerequisite.GroupType.All,
                    checkInProgression: false,
                    hideInUI: true,
                    isFeatureSelectionWhiteList: true)
                .AddPrerequisiteNoFeature(
                    feature: ProgressionRefs.ScalykindDomainProgressionSecondary.ToString(),
                    group: Prerequisite.GroupType.All,
                    checkInProgression: false,
                    hideInUI: true,
                    isFeatureSelectionWhiteList: true)
                .AddPrerequisiteNoFeature(
                    feature: ProgressionRefs.ScalykindDomainProgressionSeparatist.ToString(),
                    group: Prerequisite.GroupType.All,
                    checkInProgression: false,
                    hideInUI: true,
                    isFeatureSelectionWhiteList: true)
                .AddPrerequisiteNoFeature(
                    feature: FeatureRefs.ScalykindDomainAllowed.ToString(),
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
                .AddToLevelEntry(1, DragonSubdomainBaseFeatureSeparatist.FeatureName)
                .AddToLevelEntry(6, DragonSubdomainBreathWeaponFeatureSelectionSeparatist.FeatureSelectionName)
                .AddToUIGroups([FeatureRefs.ScalykindDomainBaseFeatureSeparatist.ToString(), DragonSubdomainBreathWeaponFeatureSelectionSeparatist.FeatureSelectionName])
                .SetGiveFeaturesForPreviousLevels(true)
                .SetFeaturesRankIncrease([FeatureRefs.TricksterLoreReligionScalykindDomainRankFeature.ToString()])
                .Configure();

            var addDragonSubdomainToSecondDomainsSeparatistFeatureSelection = FeatureSelectionConfigurator
                .For(FeatureSelectionRefs.SecondDomainsSeparatistSelection)
                .AddToAllFeatures(dragonSubdomainProgressionSeparatist)
                .Configure();
        }
    }
}
