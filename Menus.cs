﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using Mario_s_Lib.DataBases;

namespace Mario_s_Template
{
    internal class Menus
    {
        public const string ComboMenuID = "combomenuid";
        public const string HarassMenuID = "harassmenuid";
        public const string AutoHarassMenuID = "autoharassmenuid";
        public const string LaneClearMenuID = "laneclearmenuid";
        public const string LastHitMenuID = "lasthitmenuid";
        public const string JungleClearMenuID = "jungleclearmenuid";
        public const string KillStealMenuID = "killstealmenuid";
        public const string FleeMenuID = "fleemenuid";
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu AutoHarassMenu;
        public static Menu LaneClearMenu;
        public static Menu LasthitMenu;
        public static Menu JungleClearMenu;
        public static Menu KillStealMenu;
        public static Menu FleeMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        //These colorslider are from Mario`s Lib
        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("Justice " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower());
            ComboMenu = FirstMenu.AddSubMenu("• Combo", ComboMenuID);
            HarassMenu = FirstMenu.AddSubMenu("• Harass", HarassMenuID);
            AutoHarassMenu = FirstMenu.AddSubMenu("• AutoHarass", AutoHarassMenuID);
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear", LaneClearMenuID);
            LasthitMenu = FirstMenu.AddSubMenu("• LastHit", LastHitMenuID);
            JungleClearMenu = FirstMenu.AddSubMenu("• JungleClear", JungleClearMenuID);
            KillStealMenu = FirstMenu.AddSubMenu("• KillSteal", KillStealMenuID);
            FleeMenu = FirstMenu.AddSubMenu("• Flee", FleeMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);

            ComboMenu.AddGroupLabel("Spells");
            ComboMenu.CreateCheckBox(" - Use Q", "qUse");
            ComboMenu.CreateCheckBox(" - Use W", "wUse");
            ComboMenu.CreateCheckBox(" - Use E", "eUse");
            ComboMenu.CreateCheckBox(" - Use R", "rUse");
            ComboMenu.CreateComboBox("Select Combo", "selectCOMBO", new List<string> { "ALL-IN", "IN-OUT","FASTER" });

            HarassMenu.AddGroupLabel("Spells");
            HarassMenu.CreateCheckBox(" - Use Q", "qUse");
            HarassMenu.CreateCheckBox(" - Use W", "wUse");
            HarassMenu.AddGroupLabel("Settings");
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use Harass spells", "manaSlider", 30);

            AutoHarassMenu.AddGroupLabel("Spells");
            AutoHarassMenu.CreateCheckBox(" - Use W", "wUse");
            AutoHarassMenu.AddGroupLabel("Settings");
            AutoHarassMenu.CreateKeyBind("Enable/Disable AutoHrass", "autoHarassKey", 'Z', 'U');
            AutoHarassMenu.CreateSlider("Mana must be higher than [{0}%] to use AutoHarass spells", "manaSlider", 30);

            LaneClearMenu.AddGroupLabel("Spells");
            LaneClearMenu.CreateCheckBox(" - Use Q", "qUse");
            LaneClearMenu.CreateCheckBox(" - Use W", "wUse");
            LaneClearMenu.AddGroupLabel("Settings");
            LaneClearMenu.CreateSlider("How Much Minion W Should Hit", "wSHIT", 3, 1, 5);
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use LaneClear spells", "manaSlider", 30);

            LasthitMenu.AddGroupLabel("Spells");
            LasthitMenu.CreateCheckBox(" - Use Q", "qUse");
            LasthitMenu.CreateCheckBox(" - Use W", "wUse");
            LasthitMenu.AddGroupLabel("Settings");
            LasthitMenu.CreateSlider("Mana must be higher than [{0}%] to use LastHit spells", "manaSlider", 30);

            JungleClearMenu.AddGroupLabel("Spells");
            JungleClearMenu.CreateCheckBox(" - Use Q", "qUse");
            JungleClearMenu.CreateCheckBox(" - Use W", "wUse");
            JungleClearMenu.AddGroupLabel("Settings");
            JungleClearMenu.CreateSlider("How Much Monster W Should Hit", "wMONSTER", 2, 1, 3);
            JungleClearMenu.CreateSlider("Mana must be higher than [{0}%] to use JungleClear spells", "manaSlider", 30);

            KillStealMenu.AddGroupLabel("Spells");
            KillStealMenu.CreateCheckBox(" - Use W", "wUse");
            KillStealMenu.AddGroupLabel("Settings");
            KillStealMenu.CreateSlider("Mana must be higher than [{0}%] to use Killsteal spells", "manaSlider", 30);

            FleeMenu.AddGroupLabel("Spells");
            FleeMenu.CreateCheckBox(" - Use W", "wUse");
            FleeMenu.CreateCheckBox(" - Use E", "eUse");
            FleeMenu.CreateCheckBox(" - Use R", "rUse");
            FleeMenu.CreateComboBox("Disable Auto On Invis", "disableAUTO", new List<string> { "YES", "NO" });
            FleeMenu.AddGroupLabel("Settings");
            FleeMenu.CreateSlider("Mana must be higher than [{0}%] to use FLEE spells", "manaSlider", 30);

            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args) { Player.Instance.SetSkinId(sender.CurrentValue); };
                Player.Instance.SetSkinId(MiscMenu.Get<ComboBox>("skinComboBox").CurrentValue);
            }

            MiscMenu.AddGroupLabel("Auto Level UP");
            MiscMenu.CreateCheckBox("Activate Auto Leveler", "activateAutoLVL", false);
            MiscMenu.AddLabel("The auto leveler will always focus R than the rest of the spells");
            MiscMenu.CreateComboBox("1st Spell to focus", "firstFocus", new List<string> {"Q", "W", "E"});
            MiscMenu.CreateComboBox("2nd Spell to focus", "secondFocus", new List<string> {"Q", "W", "E"}, 1);
            MiscMenu.CreateComboBox("3rd Spell to focus", "thirdFocus", new List<string> {"Q", "W", "E"}, 2);
            MiscMenu.CreateSlider("Delay slider", "delaySlider", 200, 150, 500);

            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.CreateCheckBox(" - Draw Spell`s range only if they are ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator percent.", "perDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator statistics.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox(" - Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox(" - Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox(" - Draw E.", "eDraw");
            DrawingsMenu.CreateCheckBox(" - Draw R.", "rDraw");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.Red, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.Purple, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Orange, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.DeepPink, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.YellowGreen, "DamageIndicator Color:");
        }
    }
}