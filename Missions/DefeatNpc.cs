using Quest.Character;

namespace Quest.Missions
{
    class DefeatNpc: Mission
    {
        NPC npc;

        public DefeatNpc(NPC npc)
        {
            this.npc = npc;
        }

        override public string Describe() => $"Besiege {npc.Name} im Kampf.";
    }
}