using Project.Domain.Entities;
using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class clientProductUpdateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int License { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }

    }
}
