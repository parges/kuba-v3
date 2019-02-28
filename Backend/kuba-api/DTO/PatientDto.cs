using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace kubaapi.DTO
{
    public class PatientDto
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Tele { get; set; }
        public DateTime Birthday { get; set; }
        public IFormFile Avatar { get; set; }

    }
}
