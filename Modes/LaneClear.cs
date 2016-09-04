using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using System.Linq;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class LaneClear
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var minions =
                 EntityManager.MinionsAndMonsters.GetLaneMinions().Where(m => m.IsValidTarget(W.Range)).ToArray();
                         if (minions.Length == 0)
                                 return;
                         var pos = EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, W.Width, (int)W.Range);
                         if (pos.HitNumber >= LaneClearMenu.GetSliderValue("wSHIT"))
                             {
                                 W.TryToCast(pos.CastPosition, LaneClearMenu);
                             }

        }
    }
}