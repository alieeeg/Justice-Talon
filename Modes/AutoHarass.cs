﻿using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class AutoHarass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            W.TryToCast(target, AutoHarassMenu);
        }
    }
}