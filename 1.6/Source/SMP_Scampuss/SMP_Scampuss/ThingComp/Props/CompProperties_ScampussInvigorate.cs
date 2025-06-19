using RimWorld;
using Verse;

namespace SMP_Scampuss
{
    public class CompProperties_ScampussInvigorate : CompProperties
    {

        public CompProperties_ScampussInvigorate() => compClass = typeof(Comp_ScampussInvigorate);

        public int radius = 6;
        public int hoursBetween = 6;
        public float offset = 1f;
        public NeedDef needDef;
        public ThingDef moteDef;
        [NoTranslate]
        public string iconPath;

        public int TicksBetween()
        {
            return GenDate.TicksPerHour * hoursBetween;
        }
    }
}