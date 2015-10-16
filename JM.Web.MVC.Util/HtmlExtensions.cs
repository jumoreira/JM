using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace JM.Web.MVC.Util
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, int size, object htmlAttributes, BoxInputType type = BoxInputType.Text, bool addPlaceholder = true)
        {
            var dict = new RouteValueDictionary(htmlAttributes);
            return htmlHelper.BootstrapTextBoxFor(expression, size, dict, type, addPlaceholder);
        }
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, int size, BoxInputType type = BoxInputType.Text, bool addPlaceholder = true)
        {
            var htmlAttributes = new Dictionary<string, object>();
            return htmlHelper.BootstrapTextBoxFor(expression, size, htmlAttributes, type, addPlaceholder);
        }
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int size, IDictionary<string, object> htmlAttributes, BoxInputType type = BoxInputType.Text, bool addPlaceholder = true)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (!String.IsNullOrEmpty(labelText))
            {
                if (htmlAttributes == null)
                    htmlAttributes = new Dictionary<string, object>();
                htmlAttributes.Add("type", type.ToString());
                if (addPlaceholder)
                    htmlAttributes.Add("placeholder", labelText);
            }


            var begin = String.Format("<div class='form-group col-sm-{0}'>", size);
            var label = htmlHelper.Label(labelText).ToHtmlString();
            var strongStart = htmlHelper.Raw("<strong class='text-danger'>");
            var validation = htmlHelper.ValidationMessageFor(expression);
            var strongEnd = "</strong>";
            var field = htmlHelper.TextBoxFor(expression, htmlAttributes).ToHtmlString();
            var close = "</div>";

            return MvcHtmlString.Create(begin + label + strongStart + validation + strongEnd + field + close);
        }
    }
}
