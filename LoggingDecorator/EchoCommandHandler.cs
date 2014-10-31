namespace LoggingDecorator
{
    class EchoCommandHandler : ICommandHandler<EchoCommand>
    {
        public void Execute(EchoCommand command)
        {
            command.Echo(command.Str);
        }
    }
}
