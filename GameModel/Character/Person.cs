using System;
using System.Collections.Generic;
using System.Text;

namespace GameModel.Character
{
    public class Person:Entity
    {
        public bool IsNPC { get; set; }
        public string PlayerName { get; set; }
    }
}
