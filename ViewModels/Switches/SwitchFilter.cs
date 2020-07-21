using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webkom.Stuff;

namespace Webkom.ViewModels.Switches
{
    public class SwitchFilter : Filter
    {
        [Display(Name = "IP адрес")]
        public string IPAddress { get; set; }
        [Display(Name = "MAC адрес")]
        public string MACAddress { get; set; }
        
        [Range(1, 4096, ErrorMessage ="Знечение должно быть в интервале {1} до {2}"), Display(Name = "Идентификатор VLan")]
        //[Remote(action: "CheckRangeVLan", controller: "Switches", AdditionalFields =nameof(VLanIdMax), ErrorMessage = "Неправильный интервал значений для идентификаторов VLan")]
        public int VLanIdMin { get; set; }

        [Range(1, 4096, ErrorMessage = "Знечение должно быть в интервале {1} до {2}"), Display(Name = "Идентификатор VLan")]
        public int VLanIdMax { get; set; }

        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; }

        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; }
        
        [DataType(DataType.Date), Display(Name = "Дата покупки")]
        //[Remote(action: "CheckDateTimeRange", controller: "Switches", AdditionalFields = nameof(PurchaseDateMax), ErrorMessage = "Неправильный интервал значений для дат покупки")] 
        public DateTime PurchaseDateMin { get; set; }
        
        [DataType(DataType.Date), Display(Name = "Дата покупки")]       
        public DateTime PurchaseDateMax { get; set; }

        [DataType(DataType.Date), Display(Name = "Дата установки")]
        //[Remote(action: "CheckDateTimeRange", controller: "Switches", AdditionalFields = nameof(ConnectDateMax), ErrorMessage = "Неправильный интервал значений для дат покупки")]
        public DateTime ConnectDateMin { get; set; }
        
        [DataType(DataType.Date), Display(Name = "Дата установки")]
        public DateTime ConnectDateMax { get; set; }
        
        [Range(-10, 200, ErrorMessage = "Знечение должно быть в интервале {1} до {2}"), Display(Name = "Этаж размещения")]
        public short FloorNumberMin { get; set; }
        
        [Range(-10, 200, ErrorMessage = "Знечение должно быть в интервале {1} до {2}"), Display(Name = "Этах размещения")]
        public short FloorNumberMax { get; set; }
        
        [Display(Name = "Комментарий")]
        public string Description { get; set; }
        public bool EnableVLanIDSearch { get; set; }
        public bool EnablePuchaseDataSearch { get; set; }
        public bool EnableConnectDateSearch { get; set; }
        public bool EnableFloorNumberSearch { get; set; }
        public SwitchFilter()
        {
            PurchaseDateMin = DateTime.Now;
            PurchaseDateMax = DateTime.Now;
            ConnectDateMin = DateTime.Now;
            ConnectDateMax = DateTime.Now;
            VLanIdMin = 1;
            VLanIdMax = 1;
        }  
    }
}
