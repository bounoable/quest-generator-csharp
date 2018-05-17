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
        HashSet<Quest> quests = new HashSet<Quest>();

        public QuestManager(Player player)
        {
            this.player = player;
        }

        public void AddQuest(Quest quest) => quests.Add(quest);
        public void Abort(Quest quest) => quests.Remove(quest);
    }
}