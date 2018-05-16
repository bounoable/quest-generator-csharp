namespace Quest.Missions
{
    interface IMissionGenerator<T> where T: Mission
    {
        T Generate();
    }
}