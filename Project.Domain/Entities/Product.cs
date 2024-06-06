using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(9)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        //Navigation Properties
        public IEnumerable<ClientProduct> ClientProduct { get; set; } = new List<ClientProduct>();
    }
}
