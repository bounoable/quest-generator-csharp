using Quest.IO;

namespace Quest.Missions
{
    abstract class Mission: IDescribable
    {
        public bool Completed { get; private set; }
        
        abstract public string Describe();

        virtual public void Complete() => Completed = true;
    }
}