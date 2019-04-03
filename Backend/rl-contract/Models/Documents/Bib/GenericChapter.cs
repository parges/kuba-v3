using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rl_contract.Models.Bib
{
    public class GenericChapter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Score { get; set; }

        public List<GenericQuestion> Questions { get; set; }

    }
}
