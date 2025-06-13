using Verse;
using RimWorld;
using Verse.AI;
using Verse.Sound;

namespace SMP_Scampuss
{
    class Comp_UseEffect_ScampussBell : CompUseEffect
    {
		public CompProperties_UseEffect_ScampussBell Props
		{
			get
			{
				return (CompProperties_UseEffect_ScampussBell)props;
			}
		}

        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
            if (Props.soundDef != null)
            {
                Props.soundDef.PlayOneShot(new TargetInfo(usedBy.Position, usedBy.Map, false));
            }
            if (Props.pawnDef != null)
            {
                Pawn pawn = PawnGenerator.GeneratePawn(Props.pawnDef, usedBy.Faction);
                PawnUtility.TrySpawnHatchedOrBornPawn(pawn, usedBy);

                pawn.jobs.StartJob(new Job(JobDefOf.Nuzzle, usedBy));
                Messages.Message("SMP_ScampussAppearsNew".Translate(usedBy), pawn, MessageTypeDefOf.PositiveEvent, true);

            }
        }
    }
}
