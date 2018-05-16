using System;
using System.Collections.Generic;

namespace Quest.Rewards
{
    class RewardManager
    {
        Dictionary<Type, object> appliers = new Dictionary<Type, object>();

        public void AddApplier<T>(IRewarder<T> applier) where T: Reward
        {
            appliers.Add(typeof(T), applier);
        }

        public IRewarder<T> GetApplier<T>() where T: Reward
        {
            if (!appliers.TryGetValue(typeof(T), out object applier))
                return null;
            
            return applier as IRewarder<T>;
        }
    }
}