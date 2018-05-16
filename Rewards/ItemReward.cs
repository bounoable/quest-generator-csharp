using Quest.Items;

namespace Quest.Rewards
{
    class ItemReward: Reward
    {
        public Item Item { get; }
        public int Quantity { get; }

        public ItemReward(Item item, int quantity = 1)
        {
            Item = item;
            Quantity = quantity;
        }

        override public string Describe() => $"{Quantity}x{Item.Name}";
    }
}