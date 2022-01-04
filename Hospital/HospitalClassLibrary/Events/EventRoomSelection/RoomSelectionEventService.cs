using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventRoomSelection
{
    public class RoomSelectionEventService : ILogEventService<RoomSelectionEventParams>
    {
        private readonly IRoomSelectionEventRepository _roomSelectionEventRepository;

        public RoomSelectionEventService(IRoomSelectionEventRepository roomSelectionEventRepository)
        {
            _roomSelectionEventRepository = roomSelectionEventRepository;
        }

        public void LogEvent(RoomSelectionEventParams eventParams)
        {
            var roomSelectionEvent = new RoomSelection
            { TimeStamp = DateTime.Now };

            _roomSelectionEventRepository.LogEvent(roomSelectionEvent);
        }

        public List<RoomSelection> GetAll()
        {
            return _roomSelectionEventRepository.GetAll();
        }
    }
}
