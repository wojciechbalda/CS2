using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplikacja
{
    public class DeviceService
    {
        private List<Device> devices = new List<Device>();
        
        public Device AddDevice(Device device)
        {
            devices.Add(device);
            return device;
        }

        public Device GetDeviceById(int id)
        {
            return devices.FirstOrDefault(device => device.Id == id);
        }
        
        public List<Device> GetAllDevices()
        {
            return devices;    
        }
        
        public List<Device> GetAvailableDevices()
        {
            return devices.Where(e => e.IsAvailableToRent).ToList();
        }

        public void SetUnavailableToRentState(int id)
        {
            Device device = GetDeviceById(id);

            if (device != null && device.IsAvailableToRent)
                device.IsAvailableToRent = false;
            else
                throw new Exception(
                    "Nie możesz sprawić, aby urządzenie było niemożliwe do wypożyczenia w momencie, kiedy urządzenie już jest niemożliwe do wypożyczenia lub ktoś obecnie ma je na wypożyczeniu");
        }
    }
}