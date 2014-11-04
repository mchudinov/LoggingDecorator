using System;
using log4net;
using System.Text;
using System.Reflection;

namespace LoggingDecorator
{
    class LogDecorator<TCommand> : Decorator<TCommand>, ICommandHandler<TCommand>
    {
        static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public LogDecorator(ICommandHandler<TCommand> decorated) : base(decorated){}

        public void Execute(TCommand command)
        {
            log.InfoFormat("Entering {0}.", command.GetType().ToString());
            log.DebugFormat("Arguments {0}.", DisplayObjectInfo(command));
            try
            {
                this.decorated.Execute(command);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Exception {0}", e.Message);
            }    
        }


        static string DisplayObjectInfo(Object args)
        {
            StringBuilder sb = new StringBuilder();
            Type type = args.GetType();
            PropertyInfo[] pi = type.GetProperties();
            if (pi.Length > 0)
            {
                foreach (PropertyInfo f in pi)
                {
                    sb.Append("\r\n " + f + " = " + f.GetValue(args));
                }
            }
            else
                sb.Append("\r\n None");

            return sb.ToString();
        }
    }
}
