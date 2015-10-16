using System;
using System.ComponentModel.DataAnnotations;

namespace JM.Examples.MVC.Models
{ 
    public class Exemplo
    {
        [Display(Name = "Propriedade Texto")]
        public string PropertyString { get; set; }
        [Display(Name = "Propriedade Texto Sem Placeholder")]
        public string PropertyStringNoPlaceholder { get; set; }
        [Display(Name = "Propriedade Texto Com Placeholder")]
        public string PropertyStringWithPlaceholder { get; set; }
        [Display(Name = "Propriedade Número")]
        public int PropertyInt { get; set; }
        [Display(Name = "Propriedade Data")]
        public DateTime PropertyDate { get; set; }
    }
}