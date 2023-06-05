using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.MedicalSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<MedicalIssueComment> _medicalIssueCommentRepo;

        public MedicalIssueCommentsController(IGlobalRepository globalRepository)
        {
            this._globalRepo = globalRepository;
            this._medicalIssueCommentRepo = _globalRepo.GetRepository<MedicalIssueComment>();
        }



        [HttpGet]
        public IEnumerable<MedicalIssueComment> GetMedicalIssueComment()
        {
            return _medicalIssueCommentRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MedicalIssueComment> GetMedicalIssueCommentById(int id)
        {
            try
            {
                MedicalIssueComment medicalIssueComment = _medicalIssueCommentRepo.Get(id);
                return medicalIssueComment;
            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }
            return Ok();
        }
        // Insert

        [HttpPost]
        public ActionResult PostMedicalIssueComment(MedicalIssueComment medicalIssueComment)
        {
            try
            {
                _medicalIssueCommentRepo.Insert(medicalIssueComment);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalIssueComment);
        }
        // Update

        [HttpPut("{id}")]
        public IActionResult PutMedicalIssueComment(MedicalIssueComment medicalIssueComment)
        {


            try
            {
                if (medicalIssueComment.MedicalIssueCommentId == 0)
                {
                    return NotFound();
                }
                _medicalIssueCommentRepo.Update(medicalIssueComment);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalIssueComment);
        }

        //Delete

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalIssueComment(int id)
        {
            MedicalIssueComment medicalIssueComment = _medicalIssueCommentRepo.Get(id);
            try
            {
                if (medicalIssueComment == null)
                {
                    return NotFound();
                }
                _medicalIssueCommentRepo.Delete(medicalIssueComment);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalIssueComment);
        }
    }
}
