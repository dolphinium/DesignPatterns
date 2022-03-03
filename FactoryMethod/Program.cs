using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactoryFile());  // Type of creating a instance of customer manager
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactoryFile:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory 
            return new FileLogger();         // decide which logger you will use at create LoggerFactory class to be loosely-coupled.
            // return new DbLogger();         

        }
    }

    public class LoggerFactoryDb : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory 
            // return new FileLogger();
            return new DbLogger();          // decide which logger you will use at create LoggerFactory class to be loosely-coupled.

        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file with file logger!");
        }
    }

    public class DbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to db with Db Logger");
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
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
