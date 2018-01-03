using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter5
{
    public class CSharp1Syntax
    {
        static void GroupMethodHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Click");
        }

        static void GroupMethodHandle(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress");
        }

        static void GroupMethodHandle(object sender, MouseEventArgs e)
        {
            Console.WriteLine("MouseClick");
        }        

        public static void Main()
        {
            Button button = new Button { Text = "Click me" };
            button.Click += GroupMethodHandle;
            button.KeyPress += GroupMethodHandle;
            button.MouseClick += GroupMethodHandle;

            Form form = new Form { AutoSize = true };
            form.Controls.Add(button);
            Application.Run(form);
        }
    }
}
