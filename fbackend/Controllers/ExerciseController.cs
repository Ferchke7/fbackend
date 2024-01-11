using fbackend.Data;
using fbackend.DTO;
using fbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
// TODO : PROPERLY INIT DTOS PLEASE
namespace fbackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        ApplicationDbContext _context;
        
        public ExerciseController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost(Name = "ShareRoutine")]
        public async Task<IActionResult> ShareRoutine(Routine_DTO routine_DTO)
        {
            var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
            var userTemp = _context.Users.FirstOrDefault(u => u.Email == getEmail);
            if (userTemp != null)
            {
                var checkIfRoutineAlreadyExist = _context.Routines.FirstOrDefault(b => b.RoutineName == routine_DTO.RoutineName);
                if (checkIfRoutineAlreadyExist == null) {
                    await _context.Routines.AddAsync(
                new Routine
                {
                    User = userTemp.Name,
                    Monday = routine_DTO.Monday,
                    Tuesday = routine_DTO.Tuesday,
                    Wednesday = routine_DTO.Wednesday,
                    Thursday = routine_DTO.Thursday,
                    Friday = routine_DTO.Friday,
                    Saturday = routine_DTO.Saturday,
                    Sunday = routine_DTO.Sunday,
                    RoutineDescription = routine_DTO.RoutineDescription,
                    RoutineName = routine_DTO.RoutineName,
                }
                );
                    return Ok(_context.SaveChanges() == 1 ? "saved" : "not saved");
                }
                else
                {
                    return BadRequest("Exercise already exist");
                }
            }
            
            return BadRequest();
        }

        [HttpGet]
        [ActionName("GetAllRoutines")]
        
        public async Task<IActionResult> GetAllRoutines()
        {
            var getAll = _context.Routines.OrderByDescending(b => b.CreateDate);
            var routines = from b in getAll select new Routine_DTO(b);
            
            return Ok(routines);
        }

        [HttpGet]
        [ActionName("Temporary")]
        public string getTemp()
        {
            return "TEMPORARY";
        }

        [HttpDelete]
        [ActionName("DeleteMyRoutine")]
        public async Task<IActionResult> DeleteMyRoutine(int id)
        {
            var getEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
            var userTemp = _context.Users.FirstOrDefault(u => u.Email == getEmail);
            var routine = _context.Routines.Find(id);
            if (routine.User == userTemp.Name && userTemp != null)
            {
                _context.Routines.Remove(routine);
                return Ok(await _context.SaveChangesAsync() == 1 ? "saved" : "not saved");
            }
            else return BadRequest();

        }
    }
}
