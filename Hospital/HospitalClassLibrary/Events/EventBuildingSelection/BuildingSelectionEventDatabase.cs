using HospitalClassLibrary.Data;
using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalClassLibrary.Events.EventBuildingSelection
{
    public class BuildingSelectionEventDatabase : EventDatabase<BuildingSelection>, IBuildingSelectionEventRepository
    {
        public BuildingSelectionEventDatabase(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(BuildingSelection @event)
        {
            DbContext.BuildingSelection.Add(@event);
            DbContext.SaveChanges();
        }

        public List<BuildingSelection> GetAll()
        {
            foreach (BuildingSelection building in DbContext.BuildingSelection.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.BuildingSelection.ToList();
        }
    }
}
