using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Mario_s_Template.Modes;
using Mario_s_Lib;
using EloBuddy.SDK.Constants;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;
using System.Linq;

namespace Mario_s_Template
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Talon") return;

            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Obj_AI_Base.OnSpellCast += Obj_AI_Base_OnSpellCast;

        }
        private static void Obj_AI_Base_OnSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var checktitan = new Item(ItemId.Titanic_Hydra);
            if (sender.IsMe && args.SData.Name == "TalonNoxianDiplomacyAttack")
            {
                if (Player.Instance.HasItem(ItemId.Titanic_Hydra) && (checktitan.IsReady()) && (orbMode.HasFlag(Orbwalker.ActiveModes.Combo)))
                {
                    Player.Instance.InventoryItems.First(x => x.Id == ItemId.Titanic_Hydra).Cast();
                    Orbwalker.ResetAutoAttack();
                }
                if (Player.Instance.HasItem(ItemId.Titanic_Hydra) && (checktitan.IsReady()) && (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear)))
                {
                    Player.Instance.InventoryItems.First(x => x.Id == ItemId.Titanic_Hydra).Cast();
                    Orbwalker.ResetAutoAttack();
                }
                if (Player.Instance.HasItem(ItemId.Titanic_Hydra) && (checktitan.IsReady()) && (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit)))
                {
                    Player.Instance.InventoryItems.First(x => x.Id == ItemId.Titanic_Hydra).Cast();
                    Orbwalker.ResetAutoAttack();
                }
                if (Player.Instance.HasItem(ItemId.Titanic_Hydra) && (checktitan.IsReady()) && (orbMode.HasFlag(Orbwalker.ActiveModes.Harass)))
                {
                    Player.Instance.InventoryItems.First(x => x.Id == ItemId.Titanic_Hydra).Cast();
                    Orbwalker.ResetAutoAttack();
                }
                if (Player.Instance.HasItem(ItemId.Titanic_Hydra) && (checktitan.IsReady()) && (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear)))
                {
                    Player.Instance.InventoryItems.First(x => x.Id == ItemId.Titanic_Hydra).Cast();
                    Orbwalker.ResetAutoAttack();
                }
            }
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, System.EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            if (Q.IsReady() && (orbMode.HasFlag(Orbwalker.ActiveModes.Combo)))
            {
                Q.TryToCast(Player.Instance, ComboMenu);
            }
            if (Q.IsReady() && (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear)))
            {
                Q.TryToCast(Player.Instance, LaneClearMenu);
            }
            if (Q.IsReady() && (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit)))
            {
                Q.TryToCast(Player.Instance, LasthitMenu);
            }
            if (Q.IsReady() && (orbMode.HasFlag(Orbwalker.ActiveModes.Harass)))
            {
                Q.TryToCast(Player.Instance, HarassMenu);
            }
            if (Q.IsReady() && (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear)))
            {
                Q.TryToCast(Player.Instance, JungleClearMenu);
            }
        }

    }
}