Get-ComputerInfo | Format-list -Property BiosManufacturer
Get-PhysicalDisk | ft -AutoSize DeviceId, Model, MediaType, BusType, Size