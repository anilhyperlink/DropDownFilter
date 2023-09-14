using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownFilter.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string HashValue { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
