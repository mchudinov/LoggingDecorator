using System;

namespace LoggingDecorator
{
    class EchoCommandHandler : ICommandHandler<EchoCommandData>
    {
        public void Execute(EchoCommandData data)
        {
            Echo(data.Str);
        }

        void Echo(string str)
        {
            Console.WriteLine(str);
            throw new Exception("except me!");
        }
    }
}
