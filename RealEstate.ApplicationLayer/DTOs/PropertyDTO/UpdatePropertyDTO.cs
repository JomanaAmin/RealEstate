using Microsoft.AspNetCore.Http;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.DTOs.PropertyDTO
{
    public class UpdatePropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public int PropertyTypeId { get; set; }
        public double AreaSize { get; set; }
        public bool Furnished { get; set; }
        public bool IsAvailable { get; set; }
        public string ContactPhone { get; set; }
        public string ContactWhatsapp { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
