using Microsoft.Build.Framework;
using Microsoft.VisualBasic;

namespace SistemaRRHH.Models
{
    public enum Status
    {
        Active,
        Inactive,
        Fired
    }
    public class Worker
    {
        [Required]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string WorkerID { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Address { get; set; }
        public string CivilStatus { get; set; }
        public string Profession { get; set; }
        public Status Status { get; set; }
        public string Salary { get ; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Position { get; set; }
        public ICollection<Family> FamilyMembers { get; set; }
        public Worker()
        {
            
        }
    }
   
}
