using Core.Dtos;

namespace Core.Interfaces
{
    public interface IPartsService
    {
        IEnumerable<SparePartDto> GetAll();
        SparePartDto? Get(int id);
        void Delete(int id);
        void Create(CreateSparePartDto part);
        void Edit(EditSparePartDto model);
    }
}
