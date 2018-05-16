using Quest.Items;

namespace Quest.Rewards
{
    class GoldReward: Reward
    {
        public int Amount { get; }

        public GoldReward(int amount)
        {
            Amount = amount;
        }

        override public string Describe() => $"{Amount} Gold";
    }
}