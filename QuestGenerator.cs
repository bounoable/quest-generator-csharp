using System;
using Quest.Missions;
using System.Collections.Generic;

namespace Quest
{
    class QuestGenerator
    {
        static System.Random rand = new System.Random();

        Dictionary<Type, object> missionGenerators = new Dictionary<Type, object>();
        List<Type> missionTypes = new List<Type>();

        public void AddMissionGenerator<T>(IMissionGenerator<T> generator) where T: Mission
        {
            if (!missionTypes.Contains(typeof(T))) {
                missionTypes.Add(typeof(T));
                missionGenerators.Add(typeof(T), generator);
            }
        }

        public Quest Generate()
        {
            var quest = new Quest("Fuck yoou");
            var type = missionTypes[rand.Next(0, missionTypes.Count)];

            quest.AddMission(GenerateMission(type));

            return quest;
        }

        Mission GenerateMission<T>() where T: Mission => GenerateMission(typeof(T));

        Mission GenerateMission(Type missionType)
        {
            dynamic generator = missionGenerators[missionType];
            
            return generator.Generate();
        }
    }
}