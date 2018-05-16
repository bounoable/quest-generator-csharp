using System.Collections.Generic;

namespace Quest.Items
{
    class Inventory
    {
        public int Size { get; }
        public Item[] Items => items.ToArray();
        public Gold Gold { get; private set; } = new Gold(0);

        List<Item> items = new List<Item>();

        public Inventory(int size)
        {
            Size = size;
        }

        public void Add(Item item, int quantity = 1)
        {
            if (items.Count + quantity >= Size)
                throw new InventoryFullException(this);
            
            for (int i = 0; i < quantity; ++i)
                items.Add(item);
        }

        public void Add(Gold gold)
        {
            Gold += gold;
        }

        public void Remove(Gold gold)
        {
            if (Gold - gold < 0)
                throw new NotEnoughGoldException();
            
            Gold -= gold;
        }
    }
}