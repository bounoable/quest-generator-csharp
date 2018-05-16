using System;
using System.Collections.Generic;

namespace Quest.Rewards
{
    class RewardManager
    {
        Dictionary<Type, object> rewarders = new Dictionary<Type, object>();

        public void AddRewarder<T>(IRewarder<T> applier) where T: Reward
        {
            rewarders.Add(typeof(T), applier);
        }

        public IRewarder<T> GetRewarder<T>() where T: Reward
        {
            if (!rewarders.TryGetValue(typeof(T), out object rewarder))
                return null;
            
            return rewarder as IRewarder<T>;
        }
    }
}