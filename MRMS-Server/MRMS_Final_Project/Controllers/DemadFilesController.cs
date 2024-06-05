using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.ApplicantSection;
using MRMS.Model.DemandSection;
using MRMS.Model.ViewModels;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemadFilesController : ControllerBase
    {

        private IGlobalRepository _globalRepo;
        private IGenericRepository<DemandFile> _demandFileRepo;
        private readonly IWebHostEnvironment _env;

        public DemadFilesController(IGlobalRepository globalRepo, IWebHostEnvironment env)
        {
            this._globalRepo = globalRepo;
            this._demandFileRepo = _globalRepo.GetRepository<DemandFile>();
            _env = env;
        }

        //Get DemandFiles
        [HttpGet]
        public IEnumerable<DemandFile> GetDemandFiles()
        {
            return _demandFileRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<DemandFile> GetDemandFilebyId(int id)
        {
            DemandFile demandFile = _demandFileRepo.Get(id);
            if (demandFile is null)
            {
                return NotFound();
            }
            return demandFile;

        }
        [HttpPost]
        public ActionResult PostDemandFile([FromForm] DemandFileDTO demandFile)
        {
            if (demandFile == null || demandFile.File == null)
            {
                return NotFound();
            }
            try
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(demandFile.File.FileName);
                var filePath = Path.Combine("\\Uploads\\", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    demandFile.File.CopyTo(fileStream);
                }

                var demand = new DemandFile
                {
                    DemandId = demandFile.DemandId,
                    FileTypeId = demandFile.FileTypeId,
                    Description = demandFile.Description,
                    Date = demandFile.Date,
                    Filepath = uniqueFileName
                };

                _demandFileRepo.Insert(demand);
                _globalRepo.Save();

                return Ok(demand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Post Demand File
        //[HttpPost]
        //public IActionResult PostDemandFile(DemandFile demandFile)
        //{
        //    _demandFileRepo.Insert(demandFile);
        //    _globalRepo.Save();
        //    return Ok(demandFile);
        //}

        //Update DemandFile
        [HttpPut]
        public IActionResult UpdateDemandFile(DemandFile demandFile)
        {
            if (demandFile.DemandFileId == 0)
            {
                return NotFound();
            }
            _demandFileRepo.Update(demandFile);
            _globalRepo.Save();
            return Ok(demandFile);

        }

        //Delete Demand File
        [HttpDelete("{id}")]
        public IActionResult DeleteDemandFile(int id)
        {
            DemandFile demandFile = _demandFileRepo.Get(id);
            if (demandFile == null)
            {
                return NotFound();
            }
            _demandFileRepo.Delete(demandFile);
            _globalRepo.Save();
            return Ok(demandFile);
        }
    }
}
