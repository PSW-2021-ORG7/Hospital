using HospitalClassLibrary.GraphicalEditor.Models;
using System;
using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Doctor
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public Specialization Specialization { get; set; }
        public int UsedOffDays { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
