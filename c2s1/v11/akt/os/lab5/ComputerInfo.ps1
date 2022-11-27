Get-CimInstance win32_baseboard | select Manufacturer,Product
Get-PhysicalDisk | ft -AutoSize DeviceId, Model, MediaType, BusType, Size
