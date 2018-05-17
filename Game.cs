using System;
using Quest.IO;
using System.Linq;
using Quest.Items;
using Quest.Rewards;
using Quest.Missions;
using Quest.Character;
using System.Collections.Generic;

namespace Quest
{
    class Game
    {
        bool run = true;

        Player player;
        QuestManager questManager;
        QuestGenerator questGenerator;

        public void Start()
        {
            Initialize();

            while (run)
                Update();
        }

        void Initialize()
        {
            CreatePlayer();
            MakeQuestManager();
            MakeQuestGenerator();
        }

        void CreatePlayer()
        {
            player = new Player("Anton");
        }

        void MakeQuestManager()
        {
            questManager = new QuestManager(player);
        }

        void MakeQuestGenerator()
        {
            var rewardManager = new RewardManager();

            rewardManager.AddRewarder<GoldReward>(new GoldRewarder(player.Inventory));
            rewardManager.AddRewarder<ItemReward>(new ItemRewarder(player.Inventory));

            questGenerator = new QuestGenerator(rewardManager);

            questGenerator.AddMissionGenerator<DefeatNpc>(
                new DefeatNpcGenerator(
                    new NpcFactory()
                )
            );

            questGenerator.AddRewardGenerator<GoldReward>(
                new GoldRewardGenerator(150, 0.2f)
            );
        }

        void Update()
        {
            int option = Selection.Run("Was möchtest du tun?", new string[] {
                "Aktive Quests auflisten",
                "Neue Quest starten",
                "Inventar öffnen",
            });

            switch (option) {
                case 1:
                    ListActiveQuests();
                    break;
                case 2:
                    GenerateQuest();
                    ListActiveQuests();
                    break;
                case 3:
                    break;
            }

            EndLoop();
        }

        void EndLoop()
        {
            Console.WriteLine("\n");
        }

        void ListActiveQuests()
        {
            for (int i = 0; i < questManager.Quests.Length; ++i) {
                Quest quest = questManager.Quests[i];

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Quest: {quest.Name}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Missionen:");

                foreach (Mission mission in quest.Missions) {
                    Console.ForegroundColor = mission.Completed ? ConsoleColor.Green : ConsoleColor.Yellow;
                    Console.WriteLine($"- {mission.Describe()}");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nBelohnungen:");
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (Reward reward in quest.Rewards)
                    Console.WriteLine($"- {reward.Describe()}");
                
                Console.WriteLine("\n");
            }

            Console.ForegroundColor = ConsoleColor.White;

            if (questManager.Quests.Length == 0)
                return;

            int option = Selection.Run("Was möchtest du tun?", new string[] {
                "Quest auswählen",
                "Zurück"
            });

            switch (option) {
                case 1:
                    SelectQuest();
                    break;
                case 2:
                    break;
            }
        }

        void GenerateQuest()
        {
            questManager.AddQuest(questGenerator.Generate());
        }

        void SelectQuest()
        {
            int option = Selection.Run("Wähle eine Quest", questManager.Quests.Select(q => q.Name).ToArray());

            Quest quest = questManager.Quests[option - 1];

            option = Selection.Run(quest.Name, new string[] {
                "Quest abbrechen",
                "Zurück",
            });

            switch (option) {
                case 1:
                    questManager.Abort(quest);
                    break;
                case 2:
                    break;
            }
        }
    }
}
