using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetailS.Core.Model
{
    public class BookManagementDetails
    {
        public int userBookiD { get; set; }
        [Required]
        public string userTitlE { get; set; }
        [Required]
        public int userAuthoR { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal userPricE { get; set; }

        public string autherName { get; set; }

    }
}
