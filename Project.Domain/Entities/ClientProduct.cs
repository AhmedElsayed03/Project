using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class ClientProduct
    {
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [MaxLength(150)]
        public int License { get; set; }

        //Foriegn Keys
        public int ClientId { get; set; }
        public int ProductId { get; set; }

        //Navigation Properties
        public Client Client { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
