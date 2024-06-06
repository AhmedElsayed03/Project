using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(9)]
        public int Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Class Class { get; set; }

        [Required]
        public State State { get; set; }

        //Navigation Properties
        public IEnumerable<ClientProduct> ClientProduct { get; set; } = new List<ClientProduct>();
    }
}
