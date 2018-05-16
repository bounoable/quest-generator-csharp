namespace Quest.Rewards
{
    interface IRewarder<T> where T: Reward
    {
        void Apply(T reward);
    }
}