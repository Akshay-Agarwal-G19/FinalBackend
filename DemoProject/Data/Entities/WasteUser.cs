using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.Entities
{
    public class WasteUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Org_Name { get; set; }

        [StringLength(100)]
        public string Org_Desc { get; set; }

        [StringLength(100)]
        public string Phone_No { get; set; }

        [StringLength(100)]
        public string Type { get; set; }
    }
}
