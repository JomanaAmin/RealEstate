using RealEstate.ApplicationLayer.DTOs.Property;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface IPropertyService
    {
        //im going to add basic CRUD operations here 

        //Create
        public ViewPropertyDTO AddProperty(AddPropertyDTO property);
        //Update
        public ViewPropertyDTO UpdateProperty(int id, UpdatePropertyDTO property);
        //Delete
        public ViewPropertyDTO? DeleteProperty(int id);

        //Read
        public ViewPropertyDTO? GetPropertyById(int id);
        public List<ViewPropertyDTO> GetAllProperties();
    }
}
