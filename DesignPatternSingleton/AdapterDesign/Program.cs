using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesign
{
    class Program
    {//When Adapt Different Type Project to Our Projects...
        static void Main(string[] args)
        {

        }
    }

    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("Succes!");
            Console.WriteLine("Saved!");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged Success!");
        }
    }



       //   Added from Nugget /Mesela Yaani:../ 
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Log4NetAdapter : ILogger
    {

        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
