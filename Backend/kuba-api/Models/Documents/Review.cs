using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kubaapi.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Payed { get; set; }
        public string Exercises { get; set; }
        public string Reasons { get; set; }

        public int? PatientId { get; set; }
        /*public Patient Patient { get; set; }*/

    }
}
