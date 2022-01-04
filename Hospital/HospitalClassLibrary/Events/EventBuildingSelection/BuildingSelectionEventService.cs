using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.EventBuildingSelection
{
    public class BuildingSelectionEventService : ILogEventService<BuildingSelectionEventParams>
    {
        private readonly IBuildingSelectionEventRepository _buildingSelectionEventRepository;

        public BuildingSelectionEventService(IBuildingSelectionEventRepository buildingSelectionEventRepository)
        {
            _buildingSelectionEventRepository = buildingSelectionEventRepository;
        }


        public void LogEvent(BuildingSelectionEventParams eventParams)
        {
            var buildingSelectionEvent = new BuildingSelection
            { TimeStamp = DateTime.Now };

            _buildingSelectionEventRepository.LogEvent(buildingSelectionEvent);
        }

        public List<BuildingSelection> GetAll()
        {
            return _buildingSelectionEventRepository.GetAll();
        }
    }
}
