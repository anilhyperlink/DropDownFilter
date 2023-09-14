using DropDownFilter.Models;

namespace DropDownFilter.Services.Abstraction
{
    public interface IHomeHelper
    {
        PaginationModel Filter(DropDownModel dropDownModel);
    }
}
