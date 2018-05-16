using System;

namespace Quest.Character
{
    class NpcFactory
    {
        static Random rand = new Random();

        static string[] names = new string[] {
            "Bob",
            "Sally",
            "Rupert",
            "Sägzor",
            "Napoli",
            "Takeshi",
            "Rapunzel",
        };

        public NPC Create()
        {
            return new NPC(RandomName());
        }

        static string RandomName()
        {
            return names[rand.Next(0, names.Length)];
        }
    }
}