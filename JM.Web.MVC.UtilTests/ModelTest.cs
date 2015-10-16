using System.ComponentModel.DataAnnotations;

namespace JM.Web.MVC.UtilTests
{
    public class ModelTest
    {
        [Display(Name = "Propriedade Texto")]
        public string PropertyString { get; set; }
    }
}
