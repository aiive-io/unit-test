using System;
using System.Collections.Generic;

namespace Aula03
{

    public class MyLoggerArchive
    {
        private readonly string _path;

        public MyLoggerArchive(IList<string> logs)
        {
            System.IO.File.WriteAllLines($"{_path}/{DateTime.Now.Date}.{Guid.NewGuid()}.txt", logs);
        }
    }

    public interface IMyLoggerStorage
    {
        bool IsFull();
        void Add(string log);
        void Clean();
        bool Archive();
    }

    public class MyLoggerStorage : IMyLoggerStorage
    {
        private readonly IList<MyLoggerArchive> _logArchives = new List<MyLoggerArchive>();

        public IList<string> Logs { get; private set; } = new List<string>();
        
        public bool IsFull() {
            return Logs.Count > 100;
        }

        public void Add(string log)
        {
            Logs.Add(log);
        }

        public void Clean()
        {
            Logs.Clear();
        }

        public bool Archive()
        {
            try
            {
                _logArchives.Add(new MyLoggerArchive(Logs));
                Logs.Clear();

                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }

    public class MyLogger
    {
        private IMyLoggerStorage _storage;        

        public MyLogger(IMyLoggerStorage storage)
        {
            _storage = storage;
        }

        public void Log(string log)
        {
            if (_storage.IsFull())
            {
                if(!_storage.Archive())
                {
                    throw new Exception("Falha ao armazenar log");
                }
            }

            _storage.Add(log);
        }
    }    
}
