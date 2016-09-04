using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Template
{
    public static class Extensions
    {
        /// <summary>
        /// Get total damge using the custom values provided by you in the spellmanager
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static float GetTotalDamage(this Obj_AI_Base target)
        {
            var slots = new[] {SpellSlot.Q, SpellSlot.W, SpellSlot.E, SpellSlot.R};
            var dmg = Player.Spells.Where(s => slots.Contains(s.Slot)).Sum(s => target.GetDamage(s.Slot));
            dmg += Orbwalker.CanAutoAttack ? Player.Instance.GetAutoAttackDamage(target) : 0f;

            return dmg;
        }

        /// <summary>
        /// Gets the minion that can be lasthitable by the spell using the custom damage provided by you in spellmanager
        /// </summary>
        /// <param name="spell"></param>
        /// <returns></returns>
        public static Obj_AI_Minion GetLastHitMinion(this Spell.SpellBase spell)
        {
            return
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .FirstOrDefault(
                        m =>
                            m.IsValidTarget(spell.Range) && Prediction.Health.GetPrediction(m, spell.CastDelay) <= m.GetDamage(spell.Slot) &&
                            m.IsEnemy);
        }

        /// <summary>
        /// Gets the hero that can be killable by the spell using the custom damage provided by you in spellmanager
        /// </summary>
        /// <param name="spell"></param>
        /// <returns></returns>
        public static AIHeroClient GetKillableHero(this Spell.SpellBase spell)
        {
            return
                EntityManager.Heroes.Enemies.FirstOrDefault(
                    e =>
                        e.IsValidTarget(spell.Range) && Prediction.Health.GetPrediction(e, spell.CastDelay) <= e.GetDamage(spell.Slot) &&
                        !e.HasUndyingBuff());
        }

         public static void Tiamath() 
         { 
             var tiamat = new Item(ItemId.Tiamat_Melee_Only, 400); 
             if (tiamat.IsOwned() && tiamat.IsReady()) 
             { 
                 tiamat.Cast(); 
             } 
         } 
 
 
         public static void Hydra() 
         { 
             var hydra = new Item(ItemId.Ravenous_Hydra_Melee_Only, 400); 
             if (hydra.IsOwned() && hydra.IsReady()) 
             { 
                 hydra.Cast(); 
             } 
         } 
         public static void Titanic() 
         { 
             var titanic = new Item(ItemId.Titanic_Hydra, 400); 
             if (titanic.IsOwned() && titanic.IsReady()) 
             { 
                 titanic.Cast(); 
             } 
         }
        public static void DoubleItem()
        {
            Tiamath();
            Hydra();
        }

        public static void Youmu() 
         { 
             if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) 
             { 
                 var youmu = new Item(ItemId.Youmuus_Ghostblade); 
                 if (youmu.IsOwned() && youmu.IsReady()) 
                 { 
                     youmu.Cast(); 
                 } 
             } 
         } 

    }
}