using System;
using Quest.IO;
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

            questManager.AddQuest(questGenerator.Generate());
        }

        void CreatePlayer()
        {
            player = new Player("Anton");
        }

        void MakeQuestManager()
        {
            var rewardManager = new RewardManager();

            rewardManager.AddApplier<GoldReward>(new GoldRewarder(player.Inventory));
            rewardManager.AddApplier<ItemReward>(new ItemRewarder(player.Inventory));

            questManager = new QuestManager(player, rewardManager);
        }

        void MakeQuestGenerator()
        {
            questGenerator = new QuestGenerator();

            questGenerator.AddMissionGenerator(
                new DefeatNpcGenerator(
                    new NpcFactory()
                )
            );
        }

        void Update()
        {
            var selection = new Selection("Was möchtest du tun?", new string[] {
                "Aktive Quests auflisten",
                "Neue Quest starten",
                "Inventar öffnen",
            });

            int option = selection.GetOption();

            switch (option) {
                case 1:
                    ListActiveQuests();
                    break;
                case 2:
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
            foreach (Quest quest in questManager.Quests) {
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
        }
    }
}