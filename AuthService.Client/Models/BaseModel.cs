using System.Collections.Generic;
using System.Linq;

namespace AuthService.Client.Models
{
    public class BaseModel
    {
        public bool Success
        {
            get
            {
                return Errors == null || !Errors.Any();
            }
        }

        public List<string> Errors { get; set; }
    }

    public class BaseDataModel<T> : BaseModel
    {
        public T Data { get; set; }
    }
}
