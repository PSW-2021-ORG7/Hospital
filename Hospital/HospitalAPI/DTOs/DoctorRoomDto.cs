using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.DTOs
{
    public class DoctorRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
