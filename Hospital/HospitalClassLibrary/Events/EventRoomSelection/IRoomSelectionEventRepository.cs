using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventRoomSelection
{
    public interface IRoomSelectionEventRepository : IEventRepository<RoomSelection>
    {
        List<RoomSelection> GetAll();
    }
}
