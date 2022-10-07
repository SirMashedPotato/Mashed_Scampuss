using System;
using Verse;
using RimWorld;
using Verse.Sound;

namespace SMP_Scampuss
{
    class CompProperties_UseEffect_ScampussBell : CompProperties_UseEffect
    {
        public CompProperties_UseEffect_ScampussBell()
        {
            this.compClass = typeof(Comp_UseEffect_ScampussBell);
        }

        public PawnKindDef pawnDef = null;
        public SoundDef soundDef = null;
    }
}
