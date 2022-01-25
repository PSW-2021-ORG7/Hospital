﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLibrary.Schedule.Models;

namespace HospitalClassLibrary.Schedule.Services.Interfaces
{
    public interface IDoctorScheduleService
    {
        Task<DoctorSchedule> GetByDoctorId(int id);
    }
}