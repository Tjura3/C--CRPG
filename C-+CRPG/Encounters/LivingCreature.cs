using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class LivingCreature
    {
        public int CurrentHitPoints;
        public int MaximumHitPoints;
        public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }
        public LivingCreature() { }
    }
}
