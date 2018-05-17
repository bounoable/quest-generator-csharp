using System;

namespace Quest.Rewards
{
    class GoldRewardGenerator: IRewardGenerator<GoldReward>
    {
        static Random rand = new System.Random();

        int avgGold;
        float vary;

        public GoldRewardGenerator(int avgGoldPerQuestLevel, float vary)
        {
            avgGold = avgGoldPerQuestLevel;
            this.vary = Math.Clamp(vary, 0, 1);
        }

        public GoldReward Generate(Quest quest)
        {
            int avg = avgGold * quest.Level;
            int min = (int)(avg - vary * avg);
            int max = (int)(avg + vary * avg);

            return new GoldReward(rand.Next(min, max + 1));
        }
    }
}