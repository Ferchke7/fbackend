using System.ComponentModel.DataAnnotations.Schema;

namespace fbackend.Models
{
    public class Routine
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
        public string User { get; set; }
        public string? Monday { get; set; } 
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set;}
        public string? Friday { get; set;}
        public string? Saturday { get;set; }

        public string? Sunday { get; set; } 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;


    }
}
