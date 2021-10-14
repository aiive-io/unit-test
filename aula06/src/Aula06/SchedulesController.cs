using System;

namespace Aula06
{
    public interface IDateTimeServer 
    {
        DateTime Now { get; }
    }

    public class DateTimeServer: IDateTimeServer
    {
        public DateTime Now => DateTime.Now;
    }

    public interface ISchedulerService
    {
        void Schedule(int id, DateTime date);
    }

    public class SchedulesController
    {
        private readonly IDateTimeServer _dateTimeServer;
        private readonly ISchedulerService _service;

        public SchedulesController(IDateTimeServer dateTimeServer,
            ISchedulerService service)
        {
            _dateTimeServer = dateTimeServer;
            _service = service;
        }

        public void Schedule(int id)
        {
            _service.Schedule(id, _dateTimeServer.Now);
        }
    }    
}
