using System.Linq;

using Bootstrap.Pagination;

using HtmlAgilityPack;

using Newtonsoft.Json.Linq;

namespace Form.Recover
{
    /// <summary>
    ///     HtmlDocument的扩展，来自HtmlAgilityPack，用于从JToken中获取值，并赋值给表单作为值。
    /// </summary>
    public static class HtmlDocumentExtension
    {
        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        public static void SetText(this HtmlDocument doc, string id, JToken jToken)
        {
            doc.SetText(id, jToken, id);
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetText(this HtmlDocument doc, string id, JToken jToken, string name)
        {
            doc.GetElementbyId(id).SetAttributeValue("value", jToken.Get(name));
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        public static void SetText<T>(this HtmlDocument doc, string id, JToken jToken)
        {
            doc.SetText<T>(id, jToken, id);
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetText<T>(this HtmlDocument doc, string id, JToken jToken, string name)
        {
            doc.GetElementbyId(id).SetAttributeValue("value", jToken.Get<T>(name).ToString());
        }

        /// <summary>
        ///     设置Select的当前选中项
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        public static void SetSelect(this HtmlDocument doc, string id, JToken jToken)
        {
            doc.SetSelect(id, jToken, id);
        }

        /// <summary>
        ///     设置Select的当前选中项
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetSelect(this HtmlDocument doc, string id, JToken jToken, string name)
        {
            if (jToken[name] == null)
            {
                return;
            }
            var value = jToken.Get(name);
            foreach (var node in doc.GetElementbyId(id).ChildNodes)
            {
                if (node.GetAttributeValue("value", "") == value)
                {
                    node.SetAttributeValue("selected", "selected");
                }
                else
                {
                    var attribute = node.Attributes.FirstOrDefault(a => a.Name == "selected");
                    if (attribute != null)
                    {
                        attribute.Remove();
                    }
                }
            }
        }

        /// <summary>
        ///     设置Checkbox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        public static void SetCheckbox(this HtmlDocument doc, string id, JToken jToken)
        {
            doc.SetCheckbox(id, jToken, id);
        }

        /// <summary>
        ///     设置Checkbox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetCheckbox(this HtmlDocument doc, string id, JToken jToken, string name)
        {
            var isChecked = jToken.Get<bool>(name);
            if (isChecked)
            {
                doc.GetElementbyId(id).SetAttributeValue("checked", "checked");
            }
        }

        /// <summary>
        ///     设置两个Radiobox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        /// <param name="anotherId"></param>
        public static void SetRadiobox(this HtmlDocument doc, string id, JToken jToken, string name, string anotherId)
        {
            var isChecked = jToken.Get<bool>(name);
            if (isChecked)
            {
                doc.GetElementbyId(id).SetAttributeValue("checked", "checked");
                var attribute = doc.GetElementbyId(anotherId).Attributes.FirstOrDefault(a => a.Name == "checked");
                if (attribute != null)
                {
                    attribute.Remove();
                }
            }
            else
            {
                doc.GetElementbyId(anotherId).SetAttributeValue("checked", "checked");
                var attribute = doc.GetElementbyId(id).Attributes.FirstOrDefault(a => a.Name == "checked");
                if (attribute != null)
                {
                    attribute.Remove();
                }
            }
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextByXPath(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetAttributeValue("value", jToken.Get(name));
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextByXPath<T>(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetAttributeValue("value", jToken.Get<T>(name).ToString());
        }

        /// <summary>
        ///     设置Checkbox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetCheckboxByXPath(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            var isChecked = jToken.Get<bool>(name);
            if (isChecked)
            {
                doc.DocumentNode.SelectSingleNode(xpath).SetAttributeValue("checked", "checked");
            }
        }
    }
}