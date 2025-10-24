using RealEstate.ApplicationLayer.DTOs.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface IGeneralService<TViewDTO,TViewDetailsDTO,TAddDTO,TUpdateDTO,TId>
    {


        //Create
        Task<TViewDetailsDTO> AddAsync(TAddDTO item);
        //Update
        Task<TViewDetailsDTO> UpdateAsync(TId id, TUpdateDTO item);
        //Delete
        Task<TViewDTO?> DeleteAsync(TId id);
        //Read
        Task<TViewDTO?> GetByIdAsync(TId id);
        Task<IEnumerable<TViewDTO>> GetAllAsync();
    }
}
