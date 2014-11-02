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

            var command3 = new EchoCommand();
            command3.Str = "Echo me #3";
            ICommandHandler<EchoCommand> handler1 = new LogDecorator<EchoCommand>(new EchoCommandHandler());
            ICommandHandler<EchoCommand> handler2 = new BeepDecorator<EchoCommand>(handler1);
            handler2.Execute(command3);

            Console.WriteLine("After exception");
            Console.ReadLine();
        }
    }
}
