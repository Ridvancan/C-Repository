using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager(new LoggerFactory2());
            cm.Save();
        }
    }

    //Fabrika Mantığı.
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreatLogger()
        {
            //Buisness to decide Factory.
            return new EdLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreatLogger()
        {
            //Buisness to decide Factory.
            return new NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreatLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With EDLogger");
        }
    }
    public class NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With NetLogger");
        }
    }

    public class CustomerManager
    {

        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreatLogger();
            logger.Log();
        }
    }
}
