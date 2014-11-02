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

            ICommandHandler<EchoCommand> handler1 = new LogDecorator<EchoCommand>(new EchoCommandHandler());
            handler1.Execute(command1);

            ICommandHandler<EchoCommand> handler2 = new BeepDecorator<EchoCommand>(handler1);
            handler2.Execute(command1);

            Console.WriteLine("After");
            Console.ReadLine();
        }
    }
}
