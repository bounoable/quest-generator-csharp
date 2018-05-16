using Quest.Items;

namespace Quest.Rewards
{
    class GoldRewarder: IRewarder<GoldReward>
    {
        Inventory inventory;

        public GoldRewarder(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public void Apply(GoldReward reward)
        {
            inventory.Add(new Gold(reward.Amount));
        }
    }
}