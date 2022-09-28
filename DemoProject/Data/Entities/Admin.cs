using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.Entities
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Admin_Id { get; set; }

        [StringLength(100)]
        
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

    }
}
