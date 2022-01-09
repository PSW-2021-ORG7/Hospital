using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBackToMap
{
    public class BackToMapEventService : ILogEventService<BackToMapEventParams>
    {
        private readonly IBackToMapEventRepository _BackToMapEventRepository;

        public BackToMapEventService(IBackToMapEventRepository BackToMapEventRepository)
        {
            _BackToMapEventRepository = BackToMapEventRepository;
        }


        public void LogEvent(BackToMapEventParams eventParams)
        {
            var BackToMapEvent = new BackToMap
            {
                TimeStamp = DateTime.Now,
                fromBouldingId = eventParams.fromBuildingId
            };

            _BackToMapEventRepository.LogEvent(BackToMapEvent);
        }

        public List<BackToMap> GetAll()
        {
            return _BackToMapEventRepository.GetAll();
        }
    }
}
