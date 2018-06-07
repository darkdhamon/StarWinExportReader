using System;
using System.Collections.Generic;
using System.Text;

namespace GameModel.Ship
{
    class ShipSystem
    {
        public bool CannotBeCore { get; set; }
        public bool MustBeCore { get; set; }
        public bool CannotBeForward { get; set; }
        public bool MustBeForward { get; set; }
        public bool CannotBeCentral { get; set; }
        public bool MustBeCentral { get; set; }
        public bool CannotBeAft { get; set; }
        public bool MustBeAft { get; set; }
    }
}
