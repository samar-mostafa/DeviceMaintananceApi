using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Commands
{
    public class AddBranchCommand
    {
        [Required(AllowEmptyStrings =false , ErrorMessage ="يجب ادخال الاسم")]
        public string Name { get; set; }
    }
}
