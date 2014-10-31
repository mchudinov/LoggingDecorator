namespace LoggingDecorator
{
    interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }
}
