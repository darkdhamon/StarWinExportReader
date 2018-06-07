
using GameModel.Character;

namespace GameModel.Ship
{
    class Ship:Entity
    {
        public int SizeMod { get; set; }
        public Position Position { get; set; }
        public Person Captain { get; set; }
        public Entity Owner { get; set; }
        
    }
}
