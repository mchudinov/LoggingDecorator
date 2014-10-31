using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
