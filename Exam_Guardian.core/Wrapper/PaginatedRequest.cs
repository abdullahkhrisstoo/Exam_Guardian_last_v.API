using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.Wrapper
{
    public class PaginatedRequest<T>
    {
        public PaginatedRequest(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public int PageSize { get; set; }

        public int PageNumber{ get; set; }
    }
}
