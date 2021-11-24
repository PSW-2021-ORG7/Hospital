using HospitalClassLibrary.GraphicalEditor.Models;
using System;

namespace HospitalClassLibrary.Schedule.Models
{
    public class Doctor
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public Gender Gender { get; set; }
        public Specialization Specialization { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
