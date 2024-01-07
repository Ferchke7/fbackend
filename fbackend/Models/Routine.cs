namespace fbackend.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
        public string User { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;


    }
}
