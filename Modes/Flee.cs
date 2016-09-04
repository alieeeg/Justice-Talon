using System.Linq; 
using EloBuddy; 
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;


namespace Mario_s_Template.Modes
{
    internal class Flee
    {
        public static void Execute()
        {
            var jumptarget = EntityManager.MinionsAndMonsters.EnemyMinions.OrderBy(e => e.Distance(Game.CursorPos)).FirstOrDefault();
            var target = EntityManager.Heroes.Enemies.OrderBy(e => e.Distance(Player.Instance)).FirstOrDefault();
            var youmu = new Item(ItemId.Youmuus_Ghostblade,400);
            if (youmu.IsReady())
            {
                youmu.Cast();
            }
            if (target != null)
            {
                W.TryToCast(target, FleeMenu);
            }

            if (jumptarget != null)
            {
                if (jumptarget.IsInRange(Player.Instance,E.Range))
                {
                    E.TryToCast(jumptarget, FleeMenu);
                }
                
            }
            if (!E.IsReady() && !W.IsReady() && !Player.HasBuff("TalonDisappear"))
            {
                R.TryToCast(Player.Instance, FleeMenu);
            }

        }
    }
}
