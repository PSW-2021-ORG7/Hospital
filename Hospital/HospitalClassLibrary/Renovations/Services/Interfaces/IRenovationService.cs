﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Models;

namespace HospitalClassLibrary.Renovations.Services.Interfaces
{
    public interface IRenovationService
    {
        Task<IEnumerable<SplitRenovation>> GetAllSplitRenovations();
        Task Create(SplitRenovation r);
        Task Delete(SplitRenovation r);
        Task<IEnumerable<MergeRenovation>> GetAllMergeRenovations();
        Task Create(MergeRenovation r);
        Task Delete(MergeRenovation r);
        Task<bool> CanBeMerged(MergeRenovation r);
        Task<IEnumerable<SplitRenovation>> GetAllSplitRenovationsByRoomId(int id);
        Task<IEnumerable<MergeRenovation>> GetAllMergeRenovationsByRoomId(int id);
        Task<bool> HasScheduledRenovations(int roomId);
    }
}
