using System;
using Quest.Rewards;
using Quest.Missions;
using System.Collections.Generic;

namespace Quest
{
    class QuestGenerator
    {
        static Random rand = new Random();

        RewardManager rewardManager;

        Dictionary<Type, object> missionGenerators = new Dictionary<Type, object>();
        Dictionary<Type, object> rewardGenerators = new Dictionary<Type, object>();

        List<Type> missionTypes = new List<Type>();
        List<Type> rewardTypes = new List<Type>();

        public QuestGenerator(RewardManager rewardManager)
        {
            this.rewardManager = rewardManager;
        }

        public void AddMissionGenerator<T>(IMissionGenerator<T> generator) where T: Mission
        {
            if (!missionTypes.Contains(typeof(T))) {
                missionTypes.Add(typeof(T));
                missionGenerators.Add(typeof(T), generator);
            }
        }

        public void AddRewardGenerator<T>(IRewardGenerator<T> generator) where T: Reward
        {
            if (!rewardTypes.Contains(typeof(T))) {
                rewardTypes.Add(typeof(T));
                rewardGenerators.Add(typeof(T), generator);
            }
        }

        public IRewardGenerator<T> GetRewardGenerator<T>() where T: Reward
        {
            if (!rewardGenerators.TryGetValue(typeof(T), out object generator))
                return null;
            
            return generator as IRewardGenerator<T>;
        }

        public Quest Generate()
        {
            var quest = new Quest(1, "Fuck yoou");
            var missionType = missionTypes[rand.Next(0, missionTypes.Count)];
            var rewardType = rewardTypes[rand.Next(0, rewardTypes.Count)];

            quest.AddMission(GenerateMission(missionType));
            quest.AddReward(GenerateReward(rewardType, quest));

            return quest;
        }

        Mission GenerateMission<T>() where T: Mission => GenerateMission(typeof(T));
        Mission GenerateMission(Type missionType) => ((dynamic)missionGenerators[missionType]).Generate();

        Reward GenerateReward<T>(Quest quest) where T: Reward => GenerateReward(typeof(T), quest);
        Reward GenerateReward(Type rewardType, Quest quest) => ((dynamic)rewardGenerators[rewardType]).Generate(quest);
    }
}