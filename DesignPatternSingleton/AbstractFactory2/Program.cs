using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new Factory1());
            pm.GetAll();
            

        }



    }

    public abstract class Logging 
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger:Logging
    {
        public override void Log(string message)
        {
          Console.WriteLine("Logged with Log4Net");  
        }

    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }

    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache:Caching
    {
        public override void Cache(string data)
        {
          Console.WriteLine("Cached with MemCache");
        }

        
    }
    public class RCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RCache");
        }


    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreatCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreatCaching()
        {
            return new RCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class ProductManager:IProductService
    {
        CrossCuttingConcernsFactory _crossCuttingConcernsFactory;

        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreatCaching();
        }
        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Cached");
            Console.WriteLine("Product Listed");
        }
    }
}
