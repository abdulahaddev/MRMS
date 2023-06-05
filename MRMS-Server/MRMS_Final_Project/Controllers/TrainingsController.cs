using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<Training> _trainingRepository;
        public TrainingsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._trainingRepository = _globalRepository.GetRepository<Training>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<Training> GetTraining()
        {
            return _trainingRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostTraining(Training training)
        {
            _trainingRepository.Insert(training);
            _globalRepository.Save();

            return Ok(training);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutTraining(int id, Training training)
        {
            if (id != training.TrainingId)
            {
                return BadRequest();
            }
            _trainingRepository.Update(training);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(training);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(int id)
        {
            var training = _trainingRepository.Get(id);
            if (training == null)
            {
                return NotFound();
            }
            _trainingRepository.Delete(training);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
