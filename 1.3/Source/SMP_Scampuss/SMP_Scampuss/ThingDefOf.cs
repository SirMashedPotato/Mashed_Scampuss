﻿using System;
using Verse;
using RimWorld;

namespace SMP_Scampuss
{
    [DefOf]
    public static class ThingDefOf
    {
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }

        public static ThingDef SMP_ScampussBell;
    }
}
