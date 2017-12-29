using System;

namespace Chapter2
{
    public class SimpleEvent
    {
        private EventHandler testEvent;
        public event EventHandler TestEvent
        {
            add { testEvent += value; }
            remove { testEvent -= value; }
        }

        private void Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Handled");
        }

        private void OnTestEvent(EventArgs e)
        {
            testEvent?.Invoke(this, e);
        }

        public static void Main()
        {
            SimpleEvent instance = new SimpleEvent();
            EventHandler eventHandlerDelegate = new EventHandler(instance.Handler);

            instance.TestEvent += eventHandlerDelegate;
            instance.TestEvent -= null;


            instance.OnTestEvent(EventArgs.Empty);
        }
    }
}
