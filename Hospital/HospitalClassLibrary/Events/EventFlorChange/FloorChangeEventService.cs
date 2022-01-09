using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventFlorChange
{

    public class FloorChangeEventService : ILogEventService<FloorChangeEventParams>
    {
        private readonly IFloorChangeEventRepository _FloorChangeEventRepository;

        public FloorChangeEventService(IFloorChangeEventRepository FloorChangeEventRepository)
        {
            _FloorChangeEventRepository = FloorChangeEventRepository;
        }


        public void LogEvent(FloorChangeEventParams eventParams)
        {
            var FloorChangeEvent = new FloorChange
            {
                TimeStamp = DateTime.Now,
                buildingId = eventParams.buildingId,
                fromFloor = eventParams.fromFloor,
                toFloor = eventParams.toFloor
            };

            _FloorChangeEventRepository.LogEvent(FloorChangeEvent);
        }

        public List<FloorChange> GetAll()
        {
            return _FloorChangeEventRepository.GetAll();
        }
    }
}
