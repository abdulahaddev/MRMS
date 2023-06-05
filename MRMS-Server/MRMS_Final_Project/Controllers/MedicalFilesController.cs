using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.MedicalSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalFilesController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<MedicalFile> _medicalFileRepo;

        public MedicalFilesController(IGlobalRepository globalRepository)
        {
            this._globalRepo = globalRepository;
            this._medicalFileRepo = _globalRepo.GetRepository<MedicalFile>();
        }



        [HttpGet]
        public IEnumerable<MedicalFile> GetMedicalFile()
        {
            return _medicalFileRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MedicalFile> GetMedicalFilesById(int id)
        {
            try
            {
                MedicalFile medicalFile = _medicalFileRepo.Get(id);
                return medicalFile;
            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }
            return Ok();
        }
        // Insert

        [HttpPost]
        public ActionResult PostMedicalFile(MedicalFile medicalFile)
        {
            try
            {
                _medicalFileRepo.Insert(medicalFile);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalFile);
        }
        // Update

        [HttpPut("{id}")]
        public IActionResult PutMedicalFile(MedicalFile medicalFile)
        {


            try
            {
                if (medicalFile.MedicalFileId == 0)
                {
                    return NotFound();
                }
                _medicalFileRepo.Update(medicalFile);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalFile);
        }

        //Delete

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalFile(int id)
        {
            MedicalFile medicalFile = _medicalFileRepo.Get(id);
            try
            {
                if (medicalFile == null)
                {
                    return NotFound();
                }
                _medicalFileRepo.Delete(medicalFile);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalFile);
        }
    }
}
