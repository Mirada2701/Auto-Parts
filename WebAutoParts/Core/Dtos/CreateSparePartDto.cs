using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Core.Dtos
{
    public class CreateSparePartDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public int ProviderId { get; set; }
        public string PartNumber { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool IsStock => Quantity > 0;
        public float Price { get; set; }
    }
}
