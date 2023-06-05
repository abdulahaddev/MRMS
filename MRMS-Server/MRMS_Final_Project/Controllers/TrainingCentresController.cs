using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCentresController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<TrainingCentre> _trainingCentreRepository;
        public TrainingCentresController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._trainingCentreRepository = _globalRepository.GetRepository<TrainingCentre>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<TrainingCentre> GetTrainingCentre()
        {
            return _trainingCentreRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostTrainingCentre(TrainingCentre trainingCentre)
        {
            _trainingCentreRepository.Insert(trainingCentre);
            _globalRepository.Save();

            return Ok(trainingCentre);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutTrainingCentre(int id, TrainingCentre trainingCentre)
        {
            if (id != trainingCentre.TrainingCentreId)
            {
                return BadRequest();
            }
            _trainingCentreRepository.Update(trainingCentre);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(trainingCentre);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteTrainingCentre(int id)
        {
            var trainingCentre = _trainingCentreRepository.Get(id);
            if (trainingCentre == null)
            {
                return NotFound();
            }
            _trainingCentreRepository.Delete(trainingCentre);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
