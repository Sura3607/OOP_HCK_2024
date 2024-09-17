using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6
{
    public class Notifier
    {
        public void SMS(string content)
        {
            Console.WriteLine($"SMS:\t\t{content}");
        }
        public void Email(string content)
        {
            Console.WriteLine($"Email:\t\t{content}");
        }
        public void Banking(string content)
        {
            Console.WriteLine($"Banking:\t{content}");
        }
    }
}
