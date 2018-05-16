using Quest.Character;

namespace Quest.Missions
{
    class DefeatNpcGenerator: IMissionGenerator<DefeatNpc>
    {
        NpcFactory npcFactory;

        public DefeatNpcGenerator(NpcFactory npcFactory)
        {
            this.npcFactory = npcFactory;
        }

        public DefeatNpc Generate()
        {
            return new DefeatNpc(npcFactory.Create());
        }
    }
}