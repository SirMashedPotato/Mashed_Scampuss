using Verse;
using RimWorld;

namespace SMP_Scampuss
{
    class CompProperties_UseEffect_ScampussBell : CompProperties_UseEffect
    {
        public CompProperties_UseEffect_ScampussBell()
        {
            compClass = typeof(Comp_UseEffect_ScampussBell);
        }

        public PawnKindDef pawnDef = null;
        public SoundDef soundDef = null;
    }
}
