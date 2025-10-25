using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public double AreaSize { get; set; }
        public bool Furnished { get; set; }
        public bool IsAvailable { get; set; }
        public string ContactPhone { get; set; }
        public string ContactWhatsapp { get; set; }
        public DateTime CreatedAt { get; set; } 

        public List<PropertyImage> Images { get; set; }

    }

    public class PropertyImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }

}
