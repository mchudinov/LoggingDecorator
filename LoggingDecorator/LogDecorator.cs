using System;
using log4net;

namespace LoggingDecorator
{
    class LogDecorator<TCommand> : Decorator<TCommand>, ICommandHandler<TCommand>
    {
        static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public LogDecorator(ICommandHandler<TCommand> decorated) : base(decorated){}

        public void Execute(TCommand command)
        {
            log.InfoFormat("Entering {0}.", command.GetType().ToString());
            try
            {
                this.decorated.Execute(command);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Exception {0}", e.Message);
            }    
        }
    }
}
