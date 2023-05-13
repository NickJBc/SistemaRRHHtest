using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRRHH.Models
{
    public class Family
    {
        public Family()
        {
            
        }
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Relation { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }

    }
}
