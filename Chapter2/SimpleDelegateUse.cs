using System;

namespace Chapter2
{
    delegate void StringProcessor(string input);

    class Person
    {
        string name;
        public Person(string name)
        {
            this.name = name;
        }

        public void Say(string message)
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }
    }

    class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }

    public class SimpleDelegateUse
    {
        public static void Main()
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");

            StringProcessor joinsVoice, tomsVoice, backgroundVoice;
            joinsVoice = new StringProcessor(jon.Say);
            tomsVoice = new StringProcessor(tom.Say);
            backgroundVoice = new StringProcessor(Background.Note);

            joinsVoice("Hello from Join");
            tomsVoice.Invoke("Hello, Daddy!");
            backgroundVoice("An airplane flies past.");
        }
    }
}
