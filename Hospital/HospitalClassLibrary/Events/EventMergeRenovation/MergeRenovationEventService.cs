using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventMergeRenovation
{
    public class MergeRenovationEventService : ILogEventService<MergeRenovationEventParams>
    {

            private readonly IMergeRenovationEventRepository _mergeRenovationEventRepository;

            public MergeRenovationEventService(IMergeRenovationEventRepository roomSelectionEventRepository)
            {
            _mergeRenovationEventRepository = roomSelectionEventRepository;
            }

            public void LogEvent(MergeRenovationEventParams eventParams)
            {
            var MergeRenovationEvent = new MergeRenovationEvent
            {
                FirstOldRoomId = eventParams.FirstOldRoomId,
                SecondOldRoomId = eventParams.SecondOldRoomId,
                NewRoomName = eventParams.NewRoomName,
                Start = eventParams.Start,
                End = eventParams.End,
                    TimeStamp = DateTime.Now,
                };

            _mergeRenovationEventRepository.LogEvent(MergeRenovationEvent);
            }

            public List<MergeRenovationEvent> GetAll()
            {
                return _mergeRenovationEventRepository.GetAll();
            }
        
    }
}
