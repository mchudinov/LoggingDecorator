using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using log4net;

namespace LoggingDecorator
{
    public class EchoCommandLogDecorator : EchoCommand
    {
        private readonly EchoCommand decorated;
        static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public EchoCommandLogDecorator(EchoCommand decorated)
        {
            this.decorated = decorated;
        }

        public override void Echo(string str)
        {
            log.InfoFormat("Entering {0}.", GetCurrentMethod());
            try
            {
                this.decorated.Echo(str);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Exception {0}", e.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }
    }
}
