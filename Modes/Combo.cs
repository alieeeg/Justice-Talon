using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Combo
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            //COMBO IF TARGET IS IN E RANGE AND I DONT NEED TO GET OUT
            if (ComboMenu["selectCOMBO"].Cast<ComboBox>().CurrentValue == 0)
            {
                var dusman = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                if (dusman != null)
                {
                    Extensions.Youmu();
                    if (dusman.IsValidTarget(E.Range))
                    {
                        E.TryToCast(dusman, ComboMenu);
                        W.TryToCast(dusman, ComboMenu);
                        Extensions.Tiamath();
                    }
                    if (E.IsOnCooldown && W.IsOnCooldown)
                    {
                        R.TryToCast(Player.Instance, ComboMenu);
                    }

                }
            }
            //GET OUT COMBO
            if (ComboMenu["selectCOMBO"].Cast<ComboBox>().CurrentValue == 1)
            {
                var dusman2 = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var titanic = new Item(ItemId.Titanic_Hydra, 400);
            if (dusman2 != null)
            
            {
                Extensions.Youmu();
                if (dusman2.IsValidTarget(E.Range))
                {
                    E.TryToCast(dusman2, ComboMenu);
                    W.TryToCast(dusman2, ComboMenu);
                    Extensions.Tiamath();
                }
                if (E.IsOnCooldown && W.IsOnCooldown && Q.IsOnCooldown && !titanic.IsReady() && !Player.HasBuff("TalonDisappear") && !Player.HasBuff("ItemTitanicHydraCleaveBuff"))
                {
                    R.TryToCast(Player.Instance, ComboMenu);
                }
            }
            }
        }
    }
}