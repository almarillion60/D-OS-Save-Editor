﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace D_OS_Save_Editor
{
    public class DataTable
    {
        public enum Attributes
        {
            Strength = 0,
            Dexerity,
            Intelligence,
            Consitution,
            Speed,
            Perception
        }

        public enum Abilities
        {
            ManAtArms = 0,
            ExpertMarksman,
            Scoundrel,
            SingleHanded,
            TwoHanded,
            PlaceHolder_1,
            Bow,
            Crossbow,
            ShieldSpecialist,
            PlaceHolder_2,
            ArmorSpecialist,
            Witchcraft,
            Telekinesis,
            Willpower,
            Pyrokinetic,
            Hydrosophist,
            Aerotheurge,
            Geomancer,
            Blacksmithing,
            Sneaking,
            Pickpocketing,
            Lockpicking,
            Loremaster,
            Crafting,
            Bartering,
            PlaceHolder_3,
            PlaceHolder_4,
            PlaceHolder_5,
            Charisma,
            Leadership,
            LuckyCharm,
            Bodybuilding,
            DuelWelding,
            Wand
        }

        public static Dictionary<string, string> Traits;

        public static string[] Skills =
        {

        };

        public static string[] TraitNames =
        {
            "Forgiving",
            "Vindictive",
            "Bold",
            "Cautious",
            "Altruistic",
            "Egotistical",
            "Independent",
            "Obedient",
            "Pragmatic",
            "Romantic",
            "Spiritual",
            "Materialistic",
            "Righteous",
            "Renegade",
            "Blunt",
            "Considerate",
            "Compassionate",
            "Heartless"
        };

        public static string[] TraitEffects =
        {
            "Immune to Cursed",
            "+20% chance to hit on attacks of opportunity",
            "+1 Initiative",
            "+1 Sneaking",
            "+2 Reputation",
            "+1 Bartering",
            "+1 Willpower",
            "+1 Willpower when an ally with Leadership is in sight (+2 Willpower if ally has Leadership 5 or higher)",
            "+1 Crafting",
            "+1 Lucky Charm",
            "Immune to Fear",
            "+1 Loremaster",
            "+1 Leadership",
            "+1 Pickpocketing",
            "Immune to Charmed",
            "+1 Charisma",
            "`+3% Critical Chance",
            "+20% chance to hit when backstabbing"
        };

        public static string[] GenerationBoosts =
        {
            "Armor_Boost_STR_Mod_Ring",
            "Armor__Ring_Boost_Telekinesis_Mod",
            "Weapon_Small_WaterDamage_ModSword",
            "Weapon_Small_Crit_Mod",
            "Armor__Amulet_Boost_PoisonRes_Mod",
            "Armor__Amulet_Boost_STR_Mod",
            "Armor_Unbreakable_Mod_Helmet",
            "Armor__Helmet_Boost_PER_Mod",
            "Armor_Gloves_DefenseValue_ArmorBoost_Normal",
            "Armor__Gloves_Boost_Lockpicking_Mod",
            "Armor__Body_Boost_Movement_Mod_Mid",
            "Armor_Unbreakable_Mod_Plate",
            "Weapon_Cripple_WeaponBoost_Axe",
            "Weapon_Normal_Damage_Mod_2H",
            "Armor__Ring_Boost_PoisonRes_Mod",
            "Armor_Gloves_ReflectMelee",
            "Armor_Gloves_DefenseValue_ArmorBoost_Normal_Mid",
            "Armor__Garment_Boost_EarthRes_ModLarge",
            "Armor__Garment_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor__Garment_Boost_WaterRes_Mod",
            "Armor__Shoes_Boost_Sneaking_Mod",
            "Armor__Shoes_Boost_VitalityBoost_Mod_Large_Late",
            "Armor__Belt_Boost_STR_Mod",
            "Armor__Belt_Boost_Lockpicking_Mod",
            "Armor__Belt_Boost_Initiative_Mod_Mid",
            "Armor__Armor_Boost_SlowedImmunity",
            "Armor__Shoes_Boost_VitalityBoost_Mod_Large",
            "Armor__Shoes_Boost_Movement_Mod_Medium",
            "Armor__HelmetBoost_Initiative_Mod",
            "Armor_Helmet_Small_ArmorDefense_Mod",
            "Armor__Body_Boost_DEX_Mod",
            "Armor__Body_Boost_EarthRes_ModNormal",
            "Armor__Body_Boost_VitalityBoost_Mod_Mid",
            "Armor__Gloves_Boost_Ranged_Mod",
            "Armor__Gloves_Boost_Repair_Mod",
            "Armor__Gloves_Boost_Crafting_Mod",
            "Weapon_Large_Vitality_Mod",
            "Weapon_Small_Damage_Mod_ModKnife",
            "Weapon_Movement_Dagger_WeaponBoost_Late",
            "Armor_Boost_DEX_Mod_Ring",
            "Weapon_Large_WaterDamage_ModKnife",
            "Weapon_Movement_Dagger_WeaponBoost_Huge_Late",
            "Weapon_Small_FireDamage_ModKnife",
            "Armor__Garment_Boost_AirRes_ModLarge",
            "Armor__Garment_Boost_WaterRes_ModLarge",
            "Armor__Ring_Boost_Movement_Mod_Medium",
            "Armor__Helmet_Boost_VitalityBoost_Mod",
            "Armor__Helmet_Boost_Leadership_Mod",
            "Armor__Body_Boost_AirRes_ModNormal",
            "Armor__Belt_Boost_BodyBuilding_Mod",
            "Armor__Belt_Boost_Crafting_Mod",
            "Weapon_Large_EarthDamage_ModBow",
            "Weapon_Small_Damage_Mod_2H",
            "Weapon_Crit_Huge_WeaponBoost",
            "Weapon_Leadership_Mod",
            "Weapon_Small_WaterDamage_ModBow",
            "Armor__Gloves_Boost_Pickpocket_Mod",
            "Weapon_Small_Vitality_Mod",
            "Armor__Ring_Boost_PER_Mod",
            "Armor_Small_AirResistance_ModAmulet",
            "Armor__Ring_Boost_Movement_Mod",
            "Weapon_Large_EarthDamage_ModKnife",
            "Armor_Shoes_DefenseValue_Medium_ArmorBoost_Early",
            "Armor__Shoes_Boost_Air_ModLarge",
            "Weapon_Large_FireDamage_ModKnife",
            "Weapon_Movement_Dagger_WeaponBoost_Large_Late",
            "Weapon_Large_Crit_Mod_Early",
            "Armor__Gloves_Boost_Telekinesis_Mod",
            "Armor__Gloves_Boost_Initiative_Mod",
            "Armor__Body_Boost_PER_Mod",
            "Armor__Body_Boost_VitalityBoost_Mod_LargeMid",
            "Armor__Shoes_Boost_Water_ModLarge",
            "Armor_Belt_Boost_PoisonRes_ModLarge",
            "Armor_Belt_Boost_VitalityBoost_Mod",
            "Weapon_Small_EarthDamage_ModKnife",
            "Armor_Belt_Boost_PoisonRes_Mod",
            "Armor__Garment_Boost_FireRes_Mod",
            "Armor__Garment_Boost_PoisonRes_Mod",
            "Armor_Large_FireResistance_ModRing",
            "Armor_Small_EarthResistance_ModRing",
            "Armor__Ring_Boost_PoisonRes_Mod_Large",
            "Armor__Shoes_Boost_Earth_ModLarge",
            "Armor__Belt_Boost_Repair_Mod",
            "Armor_Small_WaterResistance_ModRing",
            "Armor__Ring_Boost_Loremaster_Mod",
            "Armor__Amulet_Boost_Charisma_Mod",
            "Armor__Amulet_Boost_Initiative_Mod",
            "Armor__Body_Boost_WaterRes_ModNormal_Late",
            "Armor__Body_Boost_EarthRes_ModNormal_Late",
            "Weapon_Mute_Large_WeaponBoost_Wand",
            "Weapon_Damage_Mod_Wand",
            "Armor_Boost_Projectile_FlareStartRing",
            "Armor_Small_AirResistance_ModRing",
            "Armor__Shoes_Boost_Barter_Mod",
            "Armor__Shoes_Boost_VitalityBoost_Mod",
            "Weapon_Giant_Vitality_Mod_Mid",
            "Weapon_Medium_Damage_Mod_Wand",
            "Armor_Boost_Target_Fortify",
            "Armor_Belt_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor_Gloves_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor_Shield_Air_Amulet",
            "Armor_Path_Firefly_Garment",
            "Weapon_Small_Speed_Mod"
        };

        public static string[] StatsBoosts =
        {
            "Has_Reflection\tFalse"
        };

        /// <summary>
        /// Generation boosts that is new to GenerationBoosts but exists in Online resource
        /// </summary>
        public static string[] GenerationBoostsAddOnline;

        public static string[] StatsBoostsAddedOnline;

        /// <summary>
        /// All generation boosts found in user's savegame
        /// </summary>
        public static string[] UserGenerationBoosts = { };

        public static string[] UserStatsBoosts = { };

        /// <summary>
        /// Generation boosts found in user's savegame but missing from bost GenerationBoosts and online resource
        /// </summary>
        public static string[] UnlistedGenerationBoosts = {};

        public static string[] UnlistedStatsBoosts = { };
        
        public static bool IsOnlineBoostsGenerated { get; private set; }

        public static async void GetTableFromOnline()
        {
            const string urlAddress = @"https://onedrive.live.com/download?cid=9DD4AA09923B4AB7&resid=9DD4AA09923B4AB7%2126529&authkey=AAVymh3zCy68ums";
            var request = WebRequest.Create(urlAddress);
            IsOnlineBoostsGenerated = false;

            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null) return;
                    var boosts = new List<string>();

                    using (var sr = new StreamReader(stream))
                    {
                        string line;
                        while ((line = await sr.ReadLineAsync()) != null)
                        {
                            if (GenerationBoosts.Contains(line.Trim())) continue;
                            boosts.Add(line.Trim());
                        }

                        GenerationBoostsAddOnline = boosts.ToArray();

                        IsOnlineBoostsGenerated = true;

                        GetUnlistedStrings();
                    }
                }
            }
        }

        public static async Task GetUnlistedStrings()
        {
            // if no save game has been loaded, return
            // this would be the case when GetTableFromOnline finishes before user loads any save game
            if (UserGenerationBoosts.Length < 1) return;

            // if no online boosts, submit nothing.
            // this would be the case if the online list is no longer available when development stops or user has no internet, or slow internet
            var tick = 0;
            while (!IsOnlineBoostsGenerated)
            {
                await Task.Delay(500);
                tick++;
                // time out at 120 seconds
                if (tick > 240)
                    return;
            }

            // get genBoost
            var genBoost = UserGenerationBoosts.Where(boost => !GenerationBoosts.Contains(boost))
                .Where(boost => !GenerationBoostsAddOnline.Contains(boost)).ToList();
            UnlistedGenerationBoosts = genBoost.ToArray();
        }
    }
}