using Dapper;
using DropDownFilter.DataAccess.StoredProcedureDbAccess.Abstraction;
using DropDownFilter.Models;
using DropDownFilter.WebedureDbAccess;
using System;
using System.Data;
using System.Linq;

namespace DropDownFilter.DataAccess.StoredProcedureDbAccess.Repository
{
    public class HomeDbRepository : SqlDbRepository<UserModel>, IHomeDbRepository
    {
        public HomeDbRepository(string connectionstring) : base(connectionstring) { }

        public PaginationModel Filter(DropDownModel dropDownModel)
        {
            PaginationModel pagination = new PaginationModel();
            int pageSize = 10; // Fixed page size

            using var vconn = GetOpenConnection();
            var vParams = new DynamicParameters();
            vParams.Add("@PageSize", pageSize);
            vParams.Add("@PageNumber", dropDownModel.PageNumber);
            vParams.Add("@HasPhoto", dropDownModel.HasPhoto);
            vParams.Add("@AccountWithinDays", dropDownModel.AccountWithinDays);
            vParams.Add("@NotAccountWithinDays", dropDownModel.NotAccountWithinDays);
            vParams.Add("@FirstNameContains", dropDownModel.FirstNameContains);
            vParams.Add("@FirstNameNotContains", dropDownModel.FirstNameNotContains);
            vParams.Add("@LastNameContains", dropDownModel.LastNameContains);
            vParams.Add("@LastNameNotContains", dropDownModel.LastNameNotContains);
            vParams.Add("@EmailContains", dropDownModel.EmailContains);
            vParams.Add("@EmailNotContains", dropDownModel.EmailNotContains);

            var userList = vconn.Query<UserModel>("sp_proc_UserFilterList", vParams, commandType: CommandType.StoredProcedure);
            var totalRecord = vconn.QueryFirstOrDefault<int>("sp_proc_UserFilterCount", vParams, commandType: CommandType.StoredProcedure);

            pagination.UserList = userList.ToList();
            pagination.Pagination = new Pagination
            {
                CurrentPage = (int)dropDownModel.PageNumber,
                Totalrecord = totalRecord,
                PageRecord = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecord / pageSize),
                StartIndex = (int)((dropDownModel.PageNumber - 1) * pageSize + 1),
                EndIndex = (int)Math.Min((double)(dropDownModel.PageNumber * pageSize), totalRecord)
            };

            return pagination;
        }
    }
}