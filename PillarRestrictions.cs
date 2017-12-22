using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fougerite;
using Fougerite.Events;
using UnityEngine;

namespace PillarRestrictions
{
    public class PillarRestrictions : Fougerite.Module
    {
        public override string Name { get { return "PillarRestrictions"; } }
        public override string Author { get { return "Salva/juli"; } }
        public override string Description { get { return "PillarRestrictions"; } }
        public override Version Version { get { return new Version("1.0"); } }

        private string red = "[color #FF0000]";
        private string blue = "[color #81F7F3]";
        private string green = "[color #82FA58]";
        private string yellow = "[color #F4FA58]";
        private string orange = "[color #FF8000]";

        public override void Initialize()
        {
            Fougerite.Hooks.OnEntityDeployedWithPlacer += OnEntityDeployedWithPlacer;
        }
        public override void DeInitialize()
        {
            Fougerite.Hooks.OnEntityDeployedWithPlacer -= OnEntityDeployedWithPlacer;
        }

        public void OnEntityDeployedWithPlacer(Fougerite.Player player, Entity e, Fougerite.Player actualplacer)
        {
            if (e.Name == "WoodPillar")
            {
                int recuentodepilares = 0;
                foreach (Fougerite.Entity xx in Util.GetUtil().FindEntitiesAround(e.Location, 5f))
                {
                    if (xx.Name == "WoodPillar")
                    {
                        recuentodepilares += 1;
                    }
                }
                if (recuentodepilares >= 5)
                {
                    e.Destroy();
                    player.Inventory.AddItem("Wood Pillar", 1);
                    player.Message(orange + "Too many pillars together, try to reduce the number of pillars");
                }
            }
        }
    }
}
