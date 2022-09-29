using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.Entities
{
    public class Waste
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Waste_Id { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        [StringLength(100)]
        public string Primary_Substance { get; set; }

        [StringLength(100)]
        public int Quantity { get; set; }

        [StringLength(100)]
        public string Month { get; set; }

        [StringLength(100)]
        public string Status { get; set; } = "Pending";

        public int Energy { get; set; }
        
        public int Prod_Id { get; set; }

        public int Request_Cons_Id { get; set; }

        public int Cons_Id { get; set; }

        [StringLength(100)]
        public string Prod_Name { get; set; }

        [StringLength(100)]
        public string Request_Cons_Name { get; set; }

        [StringLength(100)]
        public string Cons_Name { get; set; }
    }
}
