using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class ClientReadDto
    {
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public Class Class { get; set; }
        public State State { get; set; }
    }
}
