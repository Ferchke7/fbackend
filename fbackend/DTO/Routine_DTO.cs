using fbackend.Models;

namespace fbackend.DTO
{
    public class Routine_DTO
    {
        public Routine_DTO(string routineName, string routineDescription, string? monday, string? tuesday, string? wednesday, string? thursday, string? friday, string? saturday, string? sunday, string user)
        {
            RoutineName = routineName;
            RoutineDescription = routineDescription;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Sunday = sunday;
            User = user;
        }
        public Routine_DTO(Routine routine)
        {
            RoutineName = routine.RoutineName;
            RoutineDescription = routine.RoutineDescription;
            Monday = routine.Monday;
            Tuesday = routine.Tuesday;
            Wednesday= routine.Wednesday;
            Thursday= routine.Thursday;
            Friday= routine.Friday;
            Saturday= routine.Saturday;
            Sunday= routine.Sunday;
            User= routine.User;
        }
        public Routine_DTO() { } 

        public string RoutineName { get; set; }
        public string RoutineDescription { get; set;}
        public string? Monday { get; set; }
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set; }
        public string? Friday { get; set; }
        public string? Saturday { get; set; }

        public string? Sunday { get; set; }

        public string? User { get; set; }

        
    }
}
