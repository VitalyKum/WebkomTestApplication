using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webkom.Models;
using Webkom.Data;

namespace Webkom.Helpers
{
    public static class SeedData        
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebkomContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebkomContext>>()
                ))
            {
                if (context.Switches.Any())
                    return;

                context.Switches.AddRange(
                    new Switch
                    {
                        IPAddress = "127.0.0.0",
                        MACAddress = "0D:0F:3A:7B:0F:2B",
                        VLanId = 2,
                        SerialNumber = "23JJ-90X09876",
                        InventoryNumber = "SW-0000001",
                        PurchaseDate = DateTime.Parse("2007-2-12"),
                        ConnectDate = DateTime.Parse("2007-2-20"),
                        FloorNumber = 0,
                        Description = "First level switches"
                    },
                    new Switch
                    {
                        IPAddress = "127.0.0.1",
                        MACAddress = "0D:0F:3A:7B:0C:4B",
                        VLanId = 4,
                        SerialNumber = "11KK-90X09321",
                        InventoryNumber = "SW-0000002",
                        PurchaseDate = DateTime.Parse("2007-2-25"),
                        ConnectDate = DateTime.Parse("2007-2-28"),
                        FloorNumber = 10,
                        Description = "First level switches"
                    },
                    new Switch
                    {
                        IPAddress = "127.0.0.2",
                        MACAddress = "3D:1F:3A:7B:1C:4A",
                        VLanId = 4,
                        SerialNumber = "22-12Z11176",
                        InventoryNumber = "SW-0000003",
                        PurchaseDate = DateTime.Parse("2008-4-02"),
                        ConnectDate = DateTime.Parse("2008-4-20"),
                        FloorNumber = 3,
                        Description = "First level switches"
                    },
                    new Switch
                    {
                        IPAddress = "127.10.0.1",
                        MACAddress = "7D:1F:9F:7B:1C:1C",
                        VLanId = 11,
                        SerialNumber = "32-12Z25429",
                        InventoryNumber = "SW-0000017",
                        PurchaseDate = DateTime.Parse("2010-8-11"),
                        ConnectDate = DateTime.Parse("2010-9-01"),
                        FloorNumber = 28,
                        Description = "Second switches level"
                    },
                    new Switch
                     {
                         IPAddress = "127.10.1.2",
                         MACAddress = "9F:1C:4A:7B:1F:4A",
                         VLanId = 1,
                         SerialNumber = "ZX-14Z25R45",
                         InventoryNumber = "SW-0000018",
                         PurchaseDate = DateTime.Parse("2010-9-12"),
                         ConnectDate = DateTime.Parse("2010-9-19"),
                         FloorNumber = 4,
                         Description = "Second switches level"
                     },
                    new Switch
                    {
                        IPAddress = "127.14.03.12",
                        MACAddress = "1C:4C:8A:3B:5F:5F",
                        VLanId = 2,
                        SerialNumber = "HG-1422HT29",
                        InventoryNumber = "SW-0000021",
                        PurchaseDate = DateTime.Parse("2010-10-05"),
                        ConnectDate = DateTime.Parse("2010-11-28"),
                        FloorNumber = 5,
                        Description = "Second switches level"
                    },
                    new Switch
                    {
                        IPAddress = "192.168.128.4",
                        MACAddress = "7D:1F:5D:7B:1F:9A",
                        VLanId = 23,
                        SerialNumber = "32-12Z25429",
                        InventoryNumber = "SW-0000022",
                        PurchaseDate = DateTime.Parse("2012-04-11"),
                        ConnectDate = DateTime.Parse("2012-04-21"),
                        FloorNumber = 7,
                        Description = "Forth switches level"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
