using Quest.Items;

namespace Quest.Character
{
    class Player
    {
        public string Name { get; }
        public Inventory Inventory { get; } = new Inventory(5);

        public Player(string name)
        {
            Name = name;
        }
    }
}