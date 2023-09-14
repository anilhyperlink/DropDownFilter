using System.Collections.Generic;

namespace DropDownFilter.Models
{
    public class PaginationModel
    {
        public Pagination Pagination { get; set; }

        public List<UserModel> UserList { get; set; }
    }
}
