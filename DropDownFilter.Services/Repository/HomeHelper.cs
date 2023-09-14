using DropDownFilter.DataAccess.DatabaseContext;
using DropDownFilter.DataAccess.StoredProcedureDbAccess.Abstraction;
using DropDownFilter.Models;
using DropDownFilter.Services.Abstraction;

namespace DropDownFilter.Services.Repository
{
    public class HomeHelper : IHomeHelper
    {
        private readonly IHomeDbRepository _homeDbRepository;
        public HomeHelper(IHomeDbRepository homeDbRepository)
        {
            _homeDbRepository = homeDbRepository;
        }

        public PaginationModel Filter(DropDownModel dropDownModel)
        {
            var userData = _homeDbRepository.Filter(dropDownModel);
            return userData;
        }
    }
}
