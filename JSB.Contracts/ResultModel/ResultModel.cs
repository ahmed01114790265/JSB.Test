using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.ResultModel
{
    public class ResultModel
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

    }
    public class ResultModel<T> : ResultModel
    {
        public T Model { get; set; }
    }
    public class ResultList<T> : ResultModel
    {
        public List<T> ModelList { get; set; }

    }
}
