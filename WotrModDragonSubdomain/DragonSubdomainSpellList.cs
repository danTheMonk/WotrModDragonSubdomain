using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;

namespace WotrModDragonSubdomain
{
    public static class DragonSubdomainSpellList
    {
        public const string SpellListName = "DragonSubdomainSpellList";
        public const string SpellListGuid = "B7C9D8E1-F2A3-4567-89AB-CDEF01234567";

        public static void Configure()
        {
            SpellLevelList singleSpellToAddForLvl0 = new(0);

            SpellLevelList singleSpellToAddForLvl1 = new(1);
            singleSpellToAddForLvl1.Spells.Add(AbilityRefs.MagicFang.Reference);

            SpellLevelList singleSpellToAddForLvl2 = new(2);
            singleSpellToAddForLvl2.Spells.Add(AbilityRefs.HoldAnimal.Reference);

            SpellLevelList singleSpellToAddForLvl3 = new(3);
            singleSpellToAddForLvl3.Spells.Add(AbilityRefs.ProtectionFromEnergy.Reference);

            SpellLevelList singleSpellToAddForLvl4 = new(4);
            singleSpellToAddForLvl4.Spells.Add(AbilityRefs.DragonsBreath.Reference);

            SpellLevelList singleSpellToAddForLvl5 = new(5);
            singleSpellToAddForLvl5.Spells.Add(AbilityRefs.AnimalGrowth.Reference);

            SpellLevelList singleSpellToAddForLvl6 = new(6);
            singleSpellToAddForLvl6.Spells.Add(AbilityRefs.FormOfTheDragonI.Reference);

            SpellLevelList singleSpellToAddForLvl7 = new(7);
            singleSpellToAddForLvl7.Spells.Add(AbilityRefs.CreepingDoom.Reference);

            SpellLevelList singleSpellToAddForLvl8 = new(8);
            singleSpellToAddForLvl8.Spells.Add(AbilityRefs.AnimalShapes.Reference);

            SpellLevelList singleSpellToAddForLvl9 = new(9);
            singleSpellToAddForLvl9.Spells.Add(AbilityRefs.Shapechange.Reference);

            SpellLevelList[] spellsToAdd =
            [
                singleSpellToAddForLvl0,
                singleSpellToAddForLvl1,
                singleSpellToAddForLvl2,
                singleSpellToAddForLvl3,
                singleSpellToAddForLvl4,
                singleSpellToAddForLvl5,
                singleSpellToAddForLvl6,
                singleSpellToAddForLvl7,
                singleSpellToAddForLvl8,
                singleSpellToAddForLvl9
            ];

            _ = SpellListConfigurator
                .New(SpellListName, SpellListGuid)
                .AddToSpellsByLevel(spellsToAdd)
                .SetIsMythic(false)
                .SetFilterByMaxLevel(0)
                .SetFilterByDescriptor(false)
                .SetDescriptor(SpellDescriptor.None)
                .SetFilterBySchool(true)
                .SetExcludeFilterSchool(false)
                .SetFilterSchool(SpellSchool.None)
                .SetFilterSchool2(SpellSchool.None)
                .Configure();
        }
    }
}