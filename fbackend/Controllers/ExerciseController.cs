using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        [HttpGet]
        public string TemporaryExercise(string name)
        {
            return "Temporary";
        }
    }
}
