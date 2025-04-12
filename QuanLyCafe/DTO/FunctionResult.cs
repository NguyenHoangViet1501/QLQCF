using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class FunctionResult<T>
    {
        public EnumErrCode ErrCode { get; set; }

        public string Desc {  get; set; }

        public T Data { get; set; }
    }
}
