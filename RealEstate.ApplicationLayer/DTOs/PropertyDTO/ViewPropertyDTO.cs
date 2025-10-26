using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.DTOs.PropertyDTO
{
    public class ViewPropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string CityName { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public string PropertyTypeName { get; set; }
        public double AreaSize { get; set; }
        public bool Furnished { get; set; }
        public bool IsAvailable { get; set; }
        public string ContactPhone { get; set; }
        public string ContactWhatsapp { get; set; }
        public string Image { get; set; } //thumbnail image url
    }
}
