using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventSplitRenovation
{
    public class SplitRenovationEvenetService : ILogEventService<SplitRenovationEventParams>
    {
      
           private readonly ISplitRenovationEventRepository _splitRenovationEventRepository;

            public SplitRenovationEvenetService(ISplitRenovationEventRepository splitRenovationEventRepository)
            {
            _splitRenovationEventRepository = splitRenovationEventRepository;
            }

            public void LogEvent(SplitRenovationEventParams eventParams)
            {
                var splitRenovationEvent = new SplitRenovationEvent
                {
                    RoomId = eventParams.RoomId,
                    EquipmentDestination = eventParams.EquipmentDestination,
                    FirstNewRoomName =  eventParams.FirstNewRoomName,
                    SecondNewRoomName = eventParams.SecondNewRoomName,
                    Start = eventParams.Start,
                    End = eventParams.End,
                    TimeStamp = DateTime.Now,
                };

            _splitRenovationEventRepository.LogEvent(splitRenovationEvent);
            }

            public List<SplitRenovationEvent> GetAll()
            {
                return _splitRenovationEventRepository.GetAll();
            }
        
    }
}
