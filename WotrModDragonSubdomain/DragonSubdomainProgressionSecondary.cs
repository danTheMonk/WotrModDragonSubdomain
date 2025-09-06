using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace WotrModDragonSubdomain
{
    public static class DragonSubdomainProgressionSecondary
    {
        public const string ProgressionName = "DragonSubdomainProgressionSecondary";
        public const string ProgressionGuid = "89091969-b1ef-493a-8175-9baa6cb03c79";

        public static void Configure()
        {
            ProgressionConfigurator
                .New(ProgressionName, ProgressionGuid)
                .CopyFrom(ProgressionRefs.ScalykindDomainProgression.Reference) // TODO: Reconcile this (remove probably)
                .SetDisplayName("DragonSubdomain.Name")
                .SetDescription("DragonSubdomain.Description")
                .AddPrerequisiteFeature(FeatureRefs.ScalykindDomainAllowed.ToString(), hideInUI: true) // Ensure the Scalykind domain is a prerequisite
                .AddToLevelEntry(4, DragonSubdomainBreathWeaponFeatureSelection.FeatureSelectionName) // Replace with feature selection
                .RemoveFromLevelEntries(4, FeatureSelectionRefs.ScalykindCompanionSelectionDomain.ToString())
                .AddLearnSpellList(characterClass: CharacterClassRefs.ClericClass.ToString(), spellList: DragonSubdomainSpellList.SpellListName)
                .AddLearnSpellList(characterClass: CharacterClassRefs.HunterClass.ToString(), spellList: DragonSubdomainSpellList.SpellListName)
                .Configure();
        }
    }
}