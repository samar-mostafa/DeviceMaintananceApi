using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Commands
{
    public class EmployeeCommand
    {
        [Required]
        [RegularExpression("^[0][0-9]{11}$")]
        [MaxLength(12,ErrorMessage ="يجب ادخال 12 رقم فقط")]
        public string MobilePhone { get; set; }
        public string NationalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int BrancheId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }


   


}
