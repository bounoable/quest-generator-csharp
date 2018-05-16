using Quest.Character;

namespace Quest.Logs
{
    class NpcDefeated: Log
    {
        NPC npc;

        public NpcDefeated(NPC npc)
        {
            this.npc = npc;
        }
        
        override public string Describe() => $"{npc.Name} besiegt";
    }
}