using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class ClientDetailsReadDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public Class Class { get; set; }
        public State State { get; set; }
    }
}
