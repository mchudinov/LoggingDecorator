using System;

namespace LoggingDecorator
{
    class BeepDecorator<TCommand> : Decorator<TCommand>, ICommandHandler<TCommand>
    {
        public BeepDecorator(ICommandHandler<TCommand> decorated) : base(decorated){}

        public void Execute(TCommand command)
        {
            this.decorated.Execute(command);
            Console.Beep();
        }
    }
}
