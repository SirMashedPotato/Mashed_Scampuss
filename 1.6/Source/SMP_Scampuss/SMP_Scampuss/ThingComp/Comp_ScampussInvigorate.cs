using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace SMP_Scampuss
{
    public class Comp_ScampussInvigorate : ThingComp
    {
        public CompProperties_ScampussInvigorate Props => (CompProperties_ScampussInvigorate)props;

        public override void CompTickInterval(int delta)
        {
            base.CompTickInterval(delta);

            if (parent.IsHashIntervalTick(Props.TicksBetween(), delta))
            {
                Pawn pawn = parent as Pawn;
                if (!pawn.Spawned || pawn.Dead)
                {
                    return;
                }
                if (pawn.Faction == null || pawn.Faction != Faction.OfPlayerSilentFail)
                {
                    return;
                }

                DoPulse();
            }
        }

        private void DoPulse()
        {
            foreach (Thing t in GenRadial.RadialDistinctThingsAround(parent.Position, parent.Map, Props.radius, true))
            {
                if (t is Pawn target)
                {
                    if (target.IsColonist)
                    {
                        target.health.GetOrAddHediff(Props.hediffDef).Severity = 1f;
                        MoteMaker.MakeInteractionBubble(target, parent as Pawn, Props.moteDef, ContentFinder<Texture2D>.Get(Props.iconPath));
                    }
                }
            }
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach(Gizmo gizmo in base.CompGetGizmosExtra()) 
            { 
                yield return gizmo; 
            }

            if (DebugSettings.ShowDevGizmos)
            {
                yield return new Command_Action
                {
                    defaultLabel = "DEV: Invigorate Pulse",
                    action = delegate ()
                    {
                        DoPulse();
                    },
                };
            }
        }

    }
}
