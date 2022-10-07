using Verse;
using RimWorld;
using UnityEngine;

namespace SMP_Scampuss
{
    class DeathActionWorker_ScampussPoof : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            if (Rand.Chance(0.05f) && corpse.InnerPawn.Faction == Faction.OfPlayerSilentFail)
            {
                GenSpawn.Spawn(ThingDefOf.Mashed_ScampussBell, corpse.Position, corpse.Map);
                Messages.Message("SMP_ScampussLeavesBell".Translate(corpse.InnerPawn.Name, ThingDefOf.Mashed_ScampussBell.label), corpse.Position.GetFirstThing(corpse.Map, ThingDefOf.Mashed_ScampussBell), MessageTypeDefOf.NeutralEvent, true);
            }
            Vector3 vector = corpse.Position.ToVector3Shifted();
            FleckMaker.ThrowDustPuffThick(new Vector3(vector.x, 0f, vector.z)
            {
                y = AltitudeLayer.MoteOverhead.AltitudeFor()
            }, corpse.Map, Rand.Range(1.5f, 3f), new Color(1f, 1f, 1f, 2.5f));

            corpse.Destroy();
        }
    }
}
