using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingDecorator
{
    class TimerDecorator<TCommand> : Decorator<TCommand>, ICommandHandler<TCommand>
    {
        public TimerDecorator(ICommandHandler<TCommand> decorated) : base(decorated){}

        public void Execute(TCommand command)
        {
            this.decorated.Execute(command);
            Console.Beep();
        }
    }
}
