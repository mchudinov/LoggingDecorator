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
            log.DebugFormat("Parameters {0}", DisplayObjectInfo(GetCurrentMethodParameters()));
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        System.Reflection.ParameterInfo[] GetCurrentMethodParameters()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().GetParameters();
        }

        static string DisplayObjectInfo(Object args)
        {
            StringBuilder sb = new StringBuilder();
            Type type = args.GetType();
            sb.Append("\r\nArguments:");
            FieldInfo[] fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
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
