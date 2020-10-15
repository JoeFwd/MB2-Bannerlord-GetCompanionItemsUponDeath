using System;
using System.Diagnostics;
using TaleWorlds.Engine;

namespace GetCompanionItemsUponDeath
{
    public partial class GetCompanionItemsUponDeathSubModule
    {
        [Conditional("TRACE")]
        public static void Error(Exception exception, string message = null)
        {
            if (message != null)
                Error(message);

            var st = new StackTrace(exception, true);
            var f = st.GetFrame(0);
            var exceptionMessage = $"{f.GetFileName()}:{f.GetFileLineNumber()}:{f.GetFileColumnNumber()}: {exception.GetType().Name}: {exception.Message}";
            
            MBDebug.ConsolePrint(exceptionMessage);
            MBDebug.ConsolePrint(exception.StackTrace);
            Debugger.Log(3, nameof(GetCompanionItemsUponDeath), exceptionMessage + Environment.NewLine);
            Debugger.Log(3, nameof(GetCompanionItemsUponDeath), exception.StackTrace + Environment.NewLine);
        }

        [Conditional("TRACE")]
        public static void Error(string message = null)
        {
            if (message == null)
                return;

            if (!message.EndsWith("\n"))
                message += Environment.NewLine;
            Debugger.Log(3, nameof(GetCompanionItemsUponDeath), message);
            Console.Error.WriteLine($"{nameof(GetCompanionItemsUponDeath)}: ERROR: {message}");
        }
        
        [Conditional("DEBUG")]
        public static void Print(string message) {
            Debugger.Log(0, nameof(GetCompanionItemsUponDeath), message + Environment.NewLine);
            Console.Error.WriteLine($"{nameof(GetCompanionItemsUponDeath)}: DEBUG: {message}");
        }
    }
}