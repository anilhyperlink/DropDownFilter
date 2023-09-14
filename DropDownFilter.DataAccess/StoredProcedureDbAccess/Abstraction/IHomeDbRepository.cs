using DropDownFilter.Models;
using DropDownFilter.StoredProcedureDbAccess;

namespace DropDownFilter.DataAccess.StoredProcedureDbAccess.Abstraction
{
    public interface IHomeDbRepository : IGenericRepository<UserModel>
    {
        PaginationModel Filter(DropDownModel dropDownModel);
    }
}
