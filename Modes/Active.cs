using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;
namespace Mario_s_Template.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class Active
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            if (ComboMenu["selectCOMBO"].Cast<ComboBox>().CurrentValue == 1 && orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Orbwalker.DisableAttacking = Player.Instance.HasBuff("TalonDisappear");
            }
            if (FleeMenu["disableAUTO"].Cast<ComboBox>().CurrentValue == 0 && orbMode.HasFlag(Orbwalker.ActiveModes.Flee))
            {
                Orbwalker.DisableAttacking = Player.Instance.HasBuff("TalonDisappear");
            }

        }
    }
}