namespace LoggingDecorator
{
    abstract class Decorator<TCommand>
    {
        protected ICommandHandler<TCommand> decorated;

        public Decorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }
    }
}
