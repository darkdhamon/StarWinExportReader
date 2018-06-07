using System;
using System.Collections.Generic;
using System.Text;

namespace GameModel.StarSystem
{
    public class Colony
    {
        public int ColonyID { get; set; }
        public int SystemID { get; set; }
        public int PlanetID { get; set; }
        public int MoonID { get; set; }
        public int FounderID { get; set; }
        public int? AllegianceID { get; set; }
    }
}
