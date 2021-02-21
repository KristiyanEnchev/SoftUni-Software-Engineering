using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personeOne = new Person();
            Person personeTwo = new Person(25);
            Person personeTree = new Person("Peter", 24);

        }
    }
}
