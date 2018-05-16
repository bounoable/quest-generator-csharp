using System;
using Quest.IO;

namespace Quest.Logs
{
    abstract class Log: IDescribable
    {
        public const int USED = 1 << 0;

        public DateTime LogDate { get; } = DateTime.Now;
        public bool IsUsed
        {
            get => HasFlag(USED);
            set => AddFlag(USED);
        }

        int mask = 0;

        public void AddFlag(int flag) => mask |= flag;
        public bool HasFlag(int flag) => (mask & flag) == flag;

        abstract public string Describe();
    }
}