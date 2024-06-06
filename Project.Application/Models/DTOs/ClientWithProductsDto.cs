using Project.Domain.Entities;
using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Models.DTOs
{
    public class ClientWithProductsDto
    {

        //Client
        public int Code { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public Class Class { get; set; }
        public State State { get; set; }

        //Products
        public IEnumerable<ProductsListReadDto> ClientProduct { get; set; } = new List<ProductsListReadDto>();


    }
}
