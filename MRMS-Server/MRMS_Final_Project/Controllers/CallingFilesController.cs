using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ApplicantSection;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingFilesController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<CallingFile> _callingFileRepository;

        public CallingFilesController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._callingFileRepository = _globalRepository.GetRepository<CallingFile>();
        }


        // GET:
        [HttpGet]
        public IEnumerable<CallingFile> GetCallingFileFiles()
        {
            return _callingFileRepository.GetAll();
        }

        //Insert:
        [HttpPost]
        public ActionResult PostCallingFile(CallingFile callingFile)
        {
            _callingFileRepository.Insert(callingFile);
            _globalRepository.Save();
            return Ok(callingFile);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutCallingFile(int id, CallingFile callingFile)
        {
            if (id != callingFile.CallingFileId)
            {
                return BadRequest();
            }

            _callingFileRepository.Update(callingFile);

            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok(callingFile);
        }
        // DELETE: 
        [HttpDelete("{id}")]
        public IActionResult DeleteCallingFile(int id)
        {
            var callingFile = _callingFileRepository.Get(id);
            if (callingFile == null)
            {
                return NotFound();
            }
            _callingFileRepository.Delete(callingFile);
            _globalRepository.Save();
            return NoContent();
        }
    }
}
