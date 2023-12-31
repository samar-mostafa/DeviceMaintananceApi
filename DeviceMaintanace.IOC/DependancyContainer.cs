﻿using DeviceMaintanace.DAL;
using DeviceMaintanace.DAL.Repositories;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.IOC
{
    public static class DependancyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBranchService,BranchService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<BranchRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<DeviceRepository>();
            services.AddScoped<DeviceTypeRepository>();
            services.AddScoped<BranchDepartmentRepository>();
            services.AddScoped<EmployeeRepository>();

        }

    }
}
