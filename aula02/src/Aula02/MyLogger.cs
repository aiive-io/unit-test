using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula02
{
    public class MyLogger
    {
        private readonly IList<string> _logs = new List<string>();

        public IReadOnlyCollection<string> Logs => new ReadOnlyCollection<string>(_logs);

        public void Log(string message)
        {
            _logs.Add(message);
        }
    }

    public interface ISendMail
    {
        void Send(string message);
    }

    public class MyLoggerV2
    {
        private readonly IList<string> _logs = new List<string>();
        private readonly ISendMail _sendMail;
        public IReadOnlyCollection<string> Logs => new ReadOnlyCollection<string>(_logs);

        public MyLoggerV2(ISendMail sendMail)
        {
            _sendMail = sendMail;
        }

        public void Log(string message)
        {
            _logs.Add(message);
            _sendMail.Send(message);
        }
    }

    public class MyLoggerV3
    {
        private readonly IList<string> _logs = new List<string>();
        private readonly ISendMail _sendMail;
        public IReadOnlyCollection<string> Logs => new ReadOnlyCollection<string>(_logs);

        public MyLoggerV3(ISendMail sendMail)
        {
            _sendMail = sendMail;
        }

        public bool Log(string message)
        {
            _logs.Add(message);
            return true;
        }
    }
}
