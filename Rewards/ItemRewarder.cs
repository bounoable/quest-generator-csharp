using Quest.Items;

namespace Quest.Rewards
{
    class ItemRewarder: IRewarder<ItemReward>
    {
        Inventory inventory;

        public ItemRewarder(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public void Apply(ItemReward item)
        {
            inventory.Add(item.Item, item.Quantity);
        }
    }
}