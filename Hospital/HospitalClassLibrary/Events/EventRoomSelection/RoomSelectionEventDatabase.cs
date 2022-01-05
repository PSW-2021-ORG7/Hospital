using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventRoomSelection
{
    public class RoomSelectionEventDatabase : EventDatabase<RoomSelection>, IRoomSelectionEventRepository
    {
        public RoomSelectionEventDatabase(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(RoomSelection @event)
        {
            DbContext.RoomSelection.Add(@event);
            DbContext.SaveChanges();
        }

        public List<RoomSelection> GetAll()
        {
            foreach (RoomSelection room in DbContext.RoomSelection.ToList())
                DbContext.Entry(room).Reload();
            return DbContext.RoomSelection.ToList();
        }
    }
}
