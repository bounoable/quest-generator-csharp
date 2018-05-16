using System;

namespace Quest.Items
{
    class InventoryFullException: OverflowException
    {
        public Inventory Inventory { get; }

        public InventoryFullException(Inventory inventory)
        {
            Inventory = inventory;
        }
    }
}