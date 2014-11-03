using System;

namespace LoggingDecorator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var command1 = new EchoCommand();
            try
            {
                command1.Echo("Echo Me #1");
            }
            catch (Exception){}

            EchoCommand command2 = new EchoCommandLogDecorator(new EchoCommand());
            command2.Echo("Echo Me #2");

            var data = new EchoCommandData{Str = "Echo Me #3"};
            ICommandHandler<EchoCommandData> handler = new BeepDecorator<EchoCommandData>(
                new LogDecorator<EchoCommandData>(
                    new EchoCommandHandler()
                )
            );
            handler.Execute(data);

            Console.WriteLine("After exception");
            Console.ReadLine();
        }
    }
}
