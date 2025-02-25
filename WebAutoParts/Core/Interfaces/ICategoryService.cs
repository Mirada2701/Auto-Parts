using Core.Dtos;


namespace Core.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto? Get(int id);
        //void Delete(int id);
        //void Create(CreateSparePartDto part);
        //void Edit(EditSparePartDto model);
    }
}
