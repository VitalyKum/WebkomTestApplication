using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace Webkom.Models
{
    public class Switch
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Значение является обязательным"), Display(Name = "IP Адрес", Prompt ="Значение в формате 255.250.255.255")]
        [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$" , ErrorMessage = "Значение должно быть в формате 255.255.255.255")]
        public string IPAddress { get; set; }
        
        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "MAC Адрес", Prompt = "Значение в формате 0A:0A:0A:0A:0A:0A")]
        [RegularExpression(@"^([0-9a-fA-F][0-9a-fA-F]:){5}([0-9a-fA-F][0-9a-fA-F])$", ErrorMessage = "Значение должно быть в формате 0A:0A:0A:0A:0A:0A")]
        public string MACAddress { get; set; }

        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "Управляющий VLan ID", Prompt ="Введите значение от 1 до 4096")]
        [Range(1, 4096, ErrorMessage ="Значение должно быть в интервале от 1 до 4096")] 
        public int VLanId { get; set; }
        
        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "Серийный номер", Prompt = "Введите текст 6 - 20 символов"), StringLength(20, MinimumLength = 6, ErrorMessage ="Длина должна быть минимум {1}, максимум {2}")] 
        [RegularExpression(@"^([A-Za-z0-9-]+)$", ErrorMessage = "Допускаются только буквы, цифры и знак \"-\" ")]
        public string SerialNumber { get; set; }
        
        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "Инвентарный номер", Prompt = "Введите текст в формате SW-0000000"), StringLength(10, MinimumLength = 10, ErrorMessage ="Длина должна быть равна {1} символов")]
        [RegularExpression(@"^(SW-[0-9]{6}[0-9])$", ErrorMessage = "Значениедолжно быть в формате WS-0000000")]
        public string InventoryNumber { get; set; }
        
        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "Дата покупки", Prompt = "Укажите дату")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        
        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "Дата установки", Prompt = "Укажите дату")]
        [DataType(DataType.Date)] 
        public DateTime ConnectDate { get; set; }
        
        [Required(ErrorMessage = "Значение является обязательным"), Display(Name = "Этаж размещения",Prompt ="введите значение -10 - 200")]
        [Range(-10, 200, ErrorMessage ="Значение должно быть в интервале -10 до 200")]
        public short FloorNumber { get; set; }
        
        [Display(Name = "Комментарий", Prompt ="Введите текст...")]
        [StringLength(300, ErrorMessage = "Значение не более 300 символов")]
        
        public string Description { get; set; }        
    }
}
