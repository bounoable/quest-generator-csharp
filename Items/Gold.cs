namespace Quest.Items
{
    struct Gold
    {
        public int Amount { get; }

        public Gold(int amount)
        {
            Amount = amount;
        }

        override public string ToString() => Amount.ToString();

        override public bool Equals(object o) => o is Gold && o != null && ((Gold)o).Amount == Amount;
        override public int GetHashCode() => Amount;

        public static Gold operator +(Gold g1, Gold g2) => new Gold(g1.Amount + g2.Amount);
        public static Gold operator -(Gold g1, Gold g2) => new Gold(g1.Amount - g2.Amount);
        public static Gold operator *(Gold g1, Gold g2) => new Gold(g1.Amount * g2.Amount);
        public static Gold operator /(Gold g1, Gold g2) => new Gold(g1.Amount / g2.Amount);
        public static bool operator ==(Gold g1, Gold g2) => g1.Amount == g2.Amount;
        public static bool operator !=(Gold g1, Gold g2) => g1.Amount != g2.Amount;
        public static bool operator <(Gold g1, Gold g2) => g1.Amount < g2.Amount;
        public static bool operator >(Gold g1, Gold g2) => g1.Amount > g2.Amount;
        public static bool operator <(Gold g1, int g2) => g1.Amount < g2;
        public static bool operator >(Gold g1, int g2) => g1.Amount > g2;
        public static bool operator <(int g1, Gold g2) => g1 < g2.Amount;
        public static bool operator >(int g1, Gold g2) => g1 > g2.Amount;
    }
}