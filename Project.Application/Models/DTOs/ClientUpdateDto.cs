using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class ClientUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public int ClientId { get; set; }
    }
}
