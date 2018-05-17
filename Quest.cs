using System.Linq;
using Quest.Rewards;
using Quest.Missions;
using System.Collections.Generic;

namespace Quest
{
    class Quest
    {
        public int Level { get; }
        public string Name { get; }
        public Reward[] Rewards => rewards.ToArray();
        public Mission[] Missions => missions.ToArray();
        public bool Completed => Missions.Where(mission => !mission.Completed).Count() == 0;

        List<Reward> rewards = new List<Reward>();
        List<Mission> missions = new List<Mission>();

        public Quest(int level, string name)
        {
            Level = level;
            Name = name;
        }

        public void AddMission(Mission mission)
        {
            if (mission != null)
                missions.Add(mission);
        }

        public void AddReward(Reward reward)
        {
            if (reward != null)
                rewards.Add(reward);
        }
    }
}