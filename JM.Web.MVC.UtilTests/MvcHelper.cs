using Moq;
using System.Collections;
using System.IO;
using System.Web.Mvc;

namespace JM.Web.MVC.UtilTests
{
    public static class MvcHelper
    {
        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel inputDictionary)
        {
            var viewData = new ViewDataDictionary<TModel>(inputDictionary);
            var mockViewContext = new Mock<ViewContext> { CallBase = true };
            mockViewContext.Setup(c => c.ViewData).Returns(viewData);
            mockViewContext.Setup(c => c.HttpContext.Items).Returns(new Hashtable());
            mockViewContext.Setup(c => c.Writer).Returns(new StringWriter());
            var result = new HtmlHelper<TModel>(mockViewContext.Object, GetViewDataContainer(viewData));
            result.ViewData.Model = inputDictionary;
            return result;
        }

        public static IViewDataContainer GetViewDataContainer(ViewDataDictionary viewData)
        {
            var mockContainer = new Mock<IViewDataContainer>();
            mockContainer.Setup(c => c.ViewData).Returns(viewData);
            return mockContainer.Object;
        }
    }
}
