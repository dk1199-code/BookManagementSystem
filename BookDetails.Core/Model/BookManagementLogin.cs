using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetailS.Core.Model
{
   public class BookManagementLogin
    {
        public int  Id { get; set; }
        [Required]
        public string AdminUsernamE { get; set; }
        [Required]
        public string AdminPassworD { get; set; }
    }
}
