using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class Maintanance
    {
        public int Id { get; set; }
        public int DeviceDetailId { get; set; }
        public DateTime CompanyDelivaryDate { get; set; }
        public DateTime EmployeeDelivaryDate { get; set; }
        public DateTime CompanyReturnedDate { get; set; }
    
        public string SolutionDescribtion { get; set; }
        public bool DeliverToEmployeeStatus { get; set; }
        public string warrantyCompanyName { get; set; }
        public bool checkReturnedFromExternalCompany { get; set; }
        public bool checkGoToDead { get; set; }
        public bool maintanceDoneInsideOffice { get; set; }
        public bool DeviceDeliveredCompletelyToCompany { get; set; }
        public string WhatWasDeliveredToCompany { get; set; }
        public int DeviceStatusId { get; set; }
       
        public string ItEmployeeFromCompany { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string ItEmployeeToCompany { get; set; }
        public string ItEmployeeMaintainer { get; set; }
        public string ItEmployeeToEmployee { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public DeviceDetail DeviceDetail { get; set; }
        [ForeignKey("ItEmployeeFromCompany")]
        public Employee ItEmployeeFC { get; set; }

        
        [ForeignKey("EmployeeMobileNumber")]
        public Employee Employee { get; set; }

       
        [ForeignKey("ItEmployeeToCompany")]
        public Employee ItEmployeeTC { get; set; }


        
        [ForeignKey("ItEmployeeMaintainer")]
        public Employee ItMaintainer { get; set; }


       
        [ForeignKey("ItEmployeeToEmployee")]
        public Employee ItEmployeeTE { get; set; }


    }
}
