namespace Quest.Rewards
{
    interface IRewardGenerator<T> where T: Reward
    {
        T Generate(Quest quest);
    }
}