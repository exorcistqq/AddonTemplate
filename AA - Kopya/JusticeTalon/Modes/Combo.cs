﻿using EloBuddy;
using EloBuddy.SDK;
// Using the config like this makes your life easier, trust me
using Settings = JusticeTalon.Config.Modes.Combo;

namespace JusticeTalon.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            var dusman = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            if (dusman != null)
            {
                ModeManager.Youmu();
                if (Config.Modes.Combo.UseW && W.IsReady() && dusman.IsValidTarget(W.Range))
                {
                    W.Cast(dusman);
                }
                if (Config.Modes.Combo.UseE && E.IsReady() && dusman.IsValidTarget(E.Range))
                {
                    E.Cast(dusman);
                }
                if (Config.Modes.Combo.UseQ && R.IsReady() && dusman.IsValidTarget(R.Range))
                {
                    Player.IssueOrder(GameObjectOrder.AttackUnit, dusman);
                }
                if (Config.Modes.Combo.UseQ && Q.IsReady() && dusman.IsValidTarget(Q.Range))
                {
                    Player.IssueOrder(GameObjectOrder.AttackUnit, dusman);
                }
                ModeManager.Useitems();
                //Remember first to check bools then other things this is the correct way
                if (Config.Modes.Combo.UseR && R.IsReady() && dusman.IsValidTarget(R.Range))
                {
                    R.Cast();
                    Core.DelayAction(() => R.Cast(), 88);
                }
                Player.IssueOrder(GameObjectOrder.AttackUnit, dusman);



            }
        }
    }
}