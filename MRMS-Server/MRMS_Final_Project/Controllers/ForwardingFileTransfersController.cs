using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardingFileTransfersController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<ForwardingFileTransfer> _forwardingFileTransferRepository;
        public ForwardingFileTransfersController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._forwardingFileTransferRepository = _globalRepository.GetRepository<ForwardingFileTransfer>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<ForwardingFileTransfer> GetForwardingFileTransfer()
        {
            return _forwardingFileTransferRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostForwardignFileTransfer(ForwardingFileTransfer forwardingFileTransfer)
        {
            _forwardingFileTransferRepository.Insert(forwardingFileTransfer);
            _globalRepository.Save();

            return Ok(forwardingFileTransfer);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutForwardingFileTransfer(int id, ForwardingFileTransfer forwardingFileTransfer)
        {
            if (id != forwardingFileTransfer.ForwardingFileTransferId)
            {
                return BadRequest();
            }
            _forwardingFileTransferRepository.Update(forwardingFileTransfer);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(forwardingFileTransfer);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteForwardingFileTransfer(int id)
        {
            var forwardingFileTransfer = _forwardingFileTransferRepository.Get(id);
            if (forwardingFileTransfer == null)
            {
                return NotFound();
            }
            _forwardingFileTransferRepository.Delete(forwardingFileTransfer);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
