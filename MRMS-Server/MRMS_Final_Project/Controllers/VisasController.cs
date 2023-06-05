using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.VisaSection;


namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisasController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<Visa> _visaRepo;


        public VisasController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._visaRepo = _globalRepo.GetRepository<Visa>();
        }

        //Get Visa
        [HttpGet]
        public IEnumerable<Visa> GetVisas()
        {
            return _visaRepo.GetAll();
        }
        //Get Visa by VisaId
        [HttpGet("{VisaId}")]
        public ActionResult<Visa> GetVisaByVisaId(int VisaId)
        {
            Visa visa = _visaRepo.Get(VisaId);
            if (visa is not null)
            {
                return visa;
            }
            return NotFound();
        }

        //Post Visa
        [HttpPost]
        public IActionResult PostVisa(Visa visa)
        {
            _visaRepo.Insert(visa);
            _globalRepo.Save();
            return Ok(visa);
        }

        //Update Visa
        [HttpPut("{id}")]
        public IActionResult PutVisa(Visa visa)
        {
            if (visa.VisaId == 0)
            {
                return NotFound();
            }
            _visaRepo.Update(visa);
            _globalRepo.Save();
            return Ok(visa);
        }

        //Delete Visa
        [HttpDelete("{VisaId}")]
        public IActionResult DeleteVisa(int VisaId)
        {
            Visa visa = _visaRepo.Get(VisaId);
            if (visa == null)
            {
                return NotFound();
            }

            _visaRepo.Delete(visa);
            _globalRepo.Save();
            return Ok(visa);
        }
    }
}
