using System.Linq;
using Quest.Rewards;
using Quest.Character;
using System.Collections.Generic;

namespace Quest
{
    class QuestManager
    {
        public Quest[] Quests => quests.ToArray();

        Player player;
        RewardManager rewardManager;
        HashSet<Quest> quests = new HashSet<Quest>();

        public QuestManager(Player player, RewardManager rewardManager)
        {
            this.player = player;
            this.rewardManager = rewardManager;
        }

        public void AddQuest(Quest quest) => quests.Add(quest);
    }
}