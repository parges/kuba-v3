using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kubaapi.Models
{
    public class TestungDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public TestungBaseData Data { get; set; }
        public string Value { get; set; }

        public int? TestungId { get; set; }

    }
    
}
