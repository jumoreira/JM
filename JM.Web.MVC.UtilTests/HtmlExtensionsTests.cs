using JM.Web.MVC.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JM.Web.MVC.UtilTests
{
    [TestClass()]
    public class HtmlExtensionsTests
    {
        ModelTest Model;

        [TestInitialize]
        public void Init()
        {
            Model = new ModelTest { PropertyString = "Test" };
        }
        private string GetBooststrapTextBoxForWithStringProperty()
        {
            var htmlHelper = MvcHelper.GetHtmlHelper(Model);
            var result = htmlHelper.BootstrapTextBoxFor(i => i.PropertyString, 1).ToString();
            return result;
        }

        #region input_Tests    
        [TestMethod()]
        public void BootstrapTextBoxForHaveFormgroupClassTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.IsTrue(result.Contains("class='form-group"), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForHaveLabelTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.IsTrue(result.Contains("label"), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForValidationStrongTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.IsTrue(result.Contains("<strong class='text-danger'>"), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForHaveInputTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.IsTrue(result.Contains("input"), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForHaveInputTypeTextTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.IsTrue(result.Contains("type=\"Text\""), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForHaveInputWithPlaceholderTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.IsTrue(result.Contains("placeholder"), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForCompletedTest()
        {
            string result = GetBooststrapTextBoxForWithStringProperty();

            Assert.AreEqual("<div class='form-group col-sm-1'><label for=\"Propriedade_Texto\">Propriedade Texto</label><strong class='text-danger'></strong><input id=\"PropertyString\" name=\"PropertyString\" placeholder=\"Propriedade Texto\" type=\"Text\" value=\"Test\" /></div>", result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForHaveInputWithCustonHtmlAttributesTest()
        {
            var htmlHelper = MvcHelper.GetHtmlHelper(Model);
            var result = htmlHelper.BootstrapTextBoxFor(i => i.PropertyString, 1, new { @class = "test" }).ToString();

            Assert.IsTrue(result.Contains("class=\"test\""), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForHaveInputAndNoUsePlaceholderTest()
        {
            var htmlHelper = MvcHelper.GetHtmlHelper(Model);
            var result = htmlHelper.BootstrapTextBoxFor(i => i.PropertyString, 1, new { @class = "test" }, addPlaceholder: false).ToString();

            Assert.IsFalse(result.Contains("placeholder"), result);
        }

        [TestMethod()]
        public void BootstrapTextBoxForInputTypeInt()
        {
            var htmlHelper = MvcHelper.GetHtmlHelper(Model);
            var result = htmlHelper.BootstrapTextBoxFor(i => i.PropertyString, 1, BoxInputType.Number).ToString();

            Assert.IsTrue(result.Contains("type=\"Number\""), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForInputTypeDate()
        {
            var htmlHelper = MvcHelper.GetHtmlHelper(Model);
            var result = htmlHelper.BootstrapTextBoxFor(i => i.PropertyString, 1, BoxInputType.Date).ToString();

            Assert.IsTrue(result.Contains("type=\"Date\""), result);
        }
        [TestMethod()]
        public void BootstrapTextBoxForInputTypePassword()
        {
            var htmlHelper = MvcHelper.GetHtmlHelper(Model);
            var result = htmlHelper.BootstrapTextBoxFor(i => i.PropertyString, 1, BoxInputType.Password).ToString();

            Assert.IsTrue(result.Contains("type=\"Password\""), result);
        }
        #endregion

    }
}