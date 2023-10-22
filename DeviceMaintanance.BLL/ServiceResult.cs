using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core
{
    public class ServiceResult
    {
        public bool IsSuccessed { get; set; }
        public object Result { get; set; }
        public Dictionary<string,string> Errors { get; set; }
        public ServiceResult()
        {
            Errors = new Dictionary<string,string>();
        }

        public static ServiceResult Success(object result=null)
        {
            return new ServiceResult { IsSuccessed = true, Result = result };
        }

        public static ServiceResult Error(string error)
        {
            var result = new ServiceResult();
            result.AddError(error);
            return result;
        }

        public ServiceResult AddError(string error , string description)
        {
           this.Errors.Add(error, description);
            return this;
        }

        public ServiceResult AddError(string description) => AddError("", description);
        

    }
}
