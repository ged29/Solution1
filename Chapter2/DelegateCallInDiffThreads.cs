using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Chapter2
{
    public class DelegateCallInDiffThreads
    {
        public delegate int TestDelegate(string data);
        public TestDelegate counter, parser;

        public DelegateCallInDiffThreads()
        {
            this.counter = new TestDelegate(CountCharacters);
            this.parser = new TestDelegate(Parse);
        }

        private int CountCharacters(string text)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Counting characters in {0}", text);
            return text.Length;
        }

        private int Parse(string text)
        {
            Thread.Sleep(100);
            Console.WriteLine("Parsing text {0}", text);
            return int.Parse(text);
        }

        private void DisplayResult(IAsyncResult result)
        {
            AsyncResult delegatedResult = (AsyncResult)result;
            string format = (string)delegatedResult.AsyncState;
            TestDelegate delegateInstance = (TestDelegate)delegatedResult.AsyncDelegate;

            Console.WriteLine(format, delegateInstance.EndInvoke(result));
        }

        public static void Main()
        {
            var instance = new DelegateCallInDiffThreads();

            AsyncCallback asyncCallback = new AsyncCallback(instance.DisplayResult);
            IAsyncResult counterResult = instance.counter.BeginInvoke("hello", asyncCallback, "Counter returned {0}");
            IAsyncResult parserResult = instance.parser.BeginInvoke("10", asyncCallback, "Parser returned {0}");
            Console.WriteLine("Main thread continuing");

            Thread.Sleep(3000);
            Console.WriteLine("Done");
        }
    }
}
