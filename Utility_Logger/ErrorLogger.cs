using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utility_Logger
{
    public class ErrorLogger
    {
        public void LogError(Exception _ErrortoWrite)
        {
            string Message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            Message += Environment.NewLine;
            Message += "|~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*|";

            Message += Environment.NewLine;
            Message += string.Format("StackTrace: {0}", _ErrortoWrite.StackTrace);
            Message += Environment.NewLine;
            Message += string.Format("Message: {0}", _ErrortoWrite.Message);
            Message += Environment.NewLine;
            Message += string.Format("TargetSite:{0}", _ErrortoWrite);
            Message += Environment.NewLine;
            Message += "|~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*\\~//*|";

            using (StreamWriter _Writter = new StreamWriter("C:\\Users\\admin2\\Desktop\\ErrorLogger", true))
            {
                _Writter.WriteLine(Message);
            }
        }
    }
}
