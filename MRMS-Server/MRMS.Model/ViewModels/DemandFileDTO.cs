using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRMS.Model.ViewModels
{
    public class DemandFileDTO
    {
        public int DemandFileId { get; set; }
        public int DemandId { get; set; }
        public int FileTypeId { get; set; }
        public string? Description { get; set; }
        public string? Filepath { get; set; }
        public IFormFile? File { get; set; }
        public DateTime Date { get; set; }
    }
}
