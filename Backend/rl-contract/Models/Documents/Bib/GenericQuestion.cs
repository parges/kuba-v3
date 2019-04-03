using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rl_contract.Models.Bib
{
    public class GenericQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }

        public int? GenericChapterId { get; set; }

    }
    
}
