using DeviceMaintanace.DAL;
using DeviceMaintanace.DAL.Repositories;
using DeviceMaintanace.Tables;
using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DeviceRepository _deviceRepository;
        private readonly DeviceTypeRepository _deviceTypeRepository;

        public DeviceService(DeviceRepository deviceRepository , DeviceTypeRepository deviceTypeRepository)
        {
            _deviceRepository = deviceRepository;
            _deviceTypeRepository = deviceTypeRepository;
        }
        public async Task<ServiceResult> AddDeviceAsync(AddDeviceCommand command)
        {
            if (command == null)
                return ServiceResult.Error("يجب ادخال جميع الحقول");
            var entity = new Device
            {
                SerialNumber = command.SerialNumber,
                DeviceModel = command.DeviceModel,
                DeviceTypeId = command.DeviceTypeId,
            };
            await _deviceRepository.InsertAsync(entity);
            var model = new DeviceVM
            {
                SerialNumber = entity.SerialNumber,
                DeviceModel = entity.DeviceModel,
                DeviceType = _deviceTypeRepository.GetById(entity.DeviceTypeId).Type
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> AddDeviceTypeAsync(string deviceType)
        {
            if (string.IsNullOrEmpty(deviceType))
                return ServiceResult.Error("يجب ادخال نوع الجهاز");

            if (_deviceTypeRepository.Exists(deviceType))
                return ServiceResult.Error("نوع الجهاز موجود بالفعل");

            var entity = new DeviceType
            {
                Type = deviceType
            };
           await _deviceTypeRepository.InsertAsync(entity);
            return ServiceResult.Success(entity);

        }

        public async Task<ServiceResult> EditDeviceAsync(string serial, EditDeviceCommand command)
        {
            var entity = _deviceRepository.GetById(serial);
            if (entity == null)
                return ServiceResult.Error("هذا الجهاز غير موجود");
            entity.DeviceTypeId = command.DeviceTypeId;
            entity.DeviceModel = command.DeviceModel;
            await _deviceRepository.UpdateAsync(entity);
            var model = new DeviceVM
            {
                SerialNumber = entity.SerialNumber,
                DeviceModel = entity.DeviceModel,
                DeviceType = _deviceTypeRepository.GetById(entity.DeviceTypeId).Type
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> EditDeviceTypeAsync(int id, string name)
        {
           var entity = _deviceTypeRepository.GetById(id);
            if (entity == null)
                return ServiceResult.Error("نوع الجهاز غير موجود");
            entity.Type = name;
            await _deviceTypeRepository.UpdateAsync(entity);    
            return ServiceResult.Success(entity);
        }

        public ServiceResult GetAllDevicesAsSelectList()
        {
            var data = _deviceRepository.AllUntracked.Select(d => d.SerialNumber).ToList();
            return ServiceResult.Success(data);
        }

        public ServiceResult GetAllDeviceTypesAsSelectList()
        {
            var data = _deviceTypeRepository.AllUntracked.ToList();
            return ServiceResult.Success(data);
        }

        public ServiceResult GetDeviceBySerial(string serial)
        {
            var entity = _deviceRepository.AllUntracked
                .SingleOrDefault(d => d.SerialNumber == serial);
            if (entity == null)
                return ServiceResult.Error("هذا الجهاز غير موجود");
            var model = new DeviceVM
            {
                SerialNumber = entity.SerialNumber,
                DeviceModel = entity.DeviceModel,
                DeviceType = _deviceTypeRepository.GetById(entity.DeviceTypeId).Type
            };
            return ServiceResult.Success(model);
        }

        public ServiceResult GetDevicesByDeviceTypeId(int id)
        {
            var data = _deviceTypeRepository.All.
                Where(d => d.Id == id).
                Include(d => d.Devices).
                Select(d=> new DevicesByDeviceTypeVM
                {
                    Type = d.Type,
                    DeviceTypeId=d.Id,
                    Devices= d.Devices.Select(d=> new DeviceVMForDeviceType
                    {
                        DeviceModel = d.DeviceModel,
                        SerialNumber=d.SerialNumber

                    }).ToList()
                }).ToList();
            var res = new List<DevicesByDeviceTypeVM>();
            return ServiceResult.Success(data);
        }

        
    }
}
