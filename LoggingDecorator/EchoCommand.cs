using System;

namespace LoggingDecorator
{
    public class EchoCommand
    {
        public string Str { get; set; }

        public virtual void Echo(string str)
        {
            Console.WriteLine(str);
            throw new Exception("except me!");
        }
    }
}
