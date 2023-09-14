
using System.Collections.Generic;

namespace DropDownFilter.Models.Comman
{
    public class ResponseModel<TEntity>
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public TEntity data { get; set; }
    }
    public class ListResponseModel<TEntity>
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public List<TEntity> data { get; set; }
    }
}
