using System;
using System.Reflection;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using UnityModManagerNet;
using WotrModDragonSubdomain.DragonBreath.Acid;
using WotrModDragonSubdomain.DragonBreath.Cold;
using WotrModDragonSubdomain.DragonBreath.Electricity;
using WotrModDragonSubdomain.DragonBreath.Fire;
using WotrModDragonSubdomain.Separatist;
using WotrModDragonSubdomain.Separatist.DragonBreath.Acid;
using WotrModDragonSubdomain.Separatist.DragonBreath.Cold;
using WotrModDragonSubdomain.Separatist.DragonBreath.Electricity;
using WotrModDragonSubdomain.Separatist.DragonBreath.Fire;

namespace WotrModDragonSubdomain
{
#if DEBUG
    [EnableReloading]
#endif
    public static class Main
    {
        internal static Harmony HarmonyInstance;
        internal static UnityModManager.ModEntry.ModLogger log;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            log = modEntry.Logger;
#if DEBUG
            modEntry.OnUnload = OnUnload;
#endif
            modEntry.OnGUI = OnGUI;
            HarmonyInstance = new Harmony(modEntry.Info.Id);
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            return true;
        }

        public static void OnGUI(UnityModManager.ModEntry modEntry)
        {

        }

#if DEBUG
        public static bool OnUnload(UnityModManager.ModEntry modEntry)
        {
            HarmonyInstance.UnpatchAll(modEntry.Info.Id);
            return true;
        }
#endif
        [HarmonyPatch(typeof(BlueprintsCache))]
        public static class BlueprintsCaches_Patch
        {
            private static bool Initialized = false;

            [HarmonyPriority(Priority.First)]
            [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
            public static void Init_Postfix()
            {
                try
                {
                    if (Initialized)
                    {
                        log.Log("Already initialized blueprints cache.");
                        return;
                    }
                    Initialized = true;
                    
                    log.Log("Patching blueprints.");
                    
                    DragonSubdomainSpellList.Configure();

                    log.Log("Configured Spell List");

                    AcidDragonBreathResource.Configure();
                    ColdDragonBreathResource.Configure();
                    ElectricityDragonBreathResource.Configure();
                    FireDragonBreathResource.Configure();

                    AcidDragonBreathResourceSeparatist.Configure();
                    ColdDragonBreathResourceSeparatist.Configure();
                    ElectricityDragonBreathResourceSeparatist.Configure();
                    FireDragonBreathResourceSeparatist.Configure();

                    log.Log("Configured Breath Resources");

                    AcidDragonBreathAbility.Configure();
                    ColdDragonBreathAbility.Configure();
                    ElectricityDragonBreathAbility.Configure();
                    FireDragonBreathAbility.Configure();

                    AcidDragonBreathAbilitySeparatist.Configure();
                    ColdDragonBreathAbilitySeparatist.Configure();
                    ElectricityDragonBreathAbilitySeparatist.Configure();
                    FireDragonBreathAbilitySeparatist.Configure();

                    log.Log("Configured Breath Abilities");

                    AcidDragonBreathFeature.Configure();
                    ColdDragonBreathFeature.Configure();
                    ElectricityDragonBreathFeature.Configure();
                    FireDragonBreathFeature.Configure();

                    AcidDragonBreathFeatureSeparatist.Configure();
                    ColdDragonBreathFeatureSeparatist.Configure();
                    ElectricityDragonBreathFeatureSeparatist.Configure();
                    FireDragonBreathFeatureSeparatist.Configure();

                    log.Log("Configured Breath Features");

                    DragonSubdomainBreathWeaponFeatureSelection.Configure();

                    DragonSubdomainBreathWeaponFeatureSelectionSeparatist.Configure();

                    log.Log("Configured Breath Weapon Feature Selections");

                    DragonSubdomainSpellListFeature.Configure();

                    log.Log("Configured Spell List Features");

                    DragonSubdomainBaseFeature.Configure();

                    DragonSubdomainBaseFeatureSeparatist.Configure();

                    log.Log("Configured Base Features");

                    DragonSubdomain.Configure();

                    DragonSubdomainProgressionSeparatist.Configure();
                }
                catch (Exception e)
                {
                    log.Log(string.Concat("Failed to initialize.", e));
                }
            }
        }
    }
}
