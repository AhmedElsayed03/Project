using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class ClientAddDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public ClassEnumViewModel Class { get; set; }
    }
}
