using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardingFilesController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<ForwardingFile> _forwardingFileRepository;
        public ForwardingFilesController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._forwardingFileRepository = _globalRepository.GetRepository<ForwardingFile>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<ForwardingFile> GetForwardingFile()
        {
            return _forwardingFileRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostForwardignFile(ForwardingFile forwardingFile)
        {
            _forwardingFileRepository.Insert(forwardingFile);
            _globalRepository.Save();

            return Ok(forwardingFile);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutForwardingFile(int id, ForwardingFile forwardingFile)
        {
            if (id != forwardingFile.ForwardingFileId)
            {
                return BadRequest();
            }
            _forwardingFileRepository.Update(forwardingFile);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(forwardingFile);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteForwardingFile(int id)
        {
            var forwardingFile = _forwardingFileRepository.Get(id);
            if (forwardingFile == null)
            {
                return NotFound();
            }
            _forwardingFileRepository.Delete(forwardingFile);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
