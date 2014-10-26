using System.Linq;

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
            doc.GetElementbyId(id).SetText(jToken, name);
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
            doc.GetElementbyId(id).SetText<T>(jToken, name);
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
            doc.GetElementbyId(id).SetSelect(jToken, name);
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
            doc.GetElementbyId(id).SetCheckbox(jToken, name);
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
            doc.GetElementbyId(id).SetRadiobox(jToken, name, doc.GetElementbyId(anotherId));
        }

        /// <summary>
        ///     设置Radiobox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        /// <param name="ids"></param>
        public static void SetRadiobox(this HtmlDocument doc, JToken jToken, string name, params string[] ids)
        {
            ids.Select(doc.GetElementbyId).ToArray().SetRadiobox(jToken, name);
        }

        /// <summary>
        ///     设置Textarea的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        public static void SetTextarea(this HtmlDocument doc, string id, JToken jToken)
        {
            doc.SetText(id, jToken, id);
        }

        /// <summary>
        ///     设置Textarea的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="id"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextarea(this HtmlDocument doc, string id, JToken jToken, string name)
        {
            doc.GetElementbyId(id).SetTextarea(jToken, name);
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextByXpath(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetText(jToken, name);
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextByXpath<T>(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetText<T>(jToken, name);
        }

        /// <summary>
        ///     设置Select的当前选中项
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetSelectByXpath(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetSelect(jToken, name);
        }

        /// <summary>
        ///     设置Checkbox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetCheckboxByXpath(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetCheckbox(jToken, name);
        }

        /// <summary>
        ///     设置两个Radiobox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        /// <param name="anotherXpath"></param>
        public static void SetRadioboxByXPath(this HtmlDocument doc, string xpath, JToken jToken, string name, string anotherXpath)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetRadiobox(jToken, name, doc.DocumentNode.SelectSingleNode(anotherXpath));
        }

        /// <summary>
        ///     设置Radiobox Input的选中状态
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        /// <param name="xpaths"></param>
        public static void SetRadioboxByXpath(this HtmlDocument doc, JToken jToken, string name, params string[] xpaths)
        {
            xpaths.Select(doc.DocumentNode.SelectSingleNode).ToArray().SetRadiobox(jToken, name);
        }

        /// <summary>
        ///     设置Textarea的value
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextareaByXpath(this HtmlDocument doc, string xpath, JToken jToken, string name)
        {
            doc.DocumentNode.SelectSingleNode(xpath).SetTextarea(jToken, name);
        }

        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="id"></param>
        /// <param name="html"></param>
        /// <param name="doc"></param>
        public static void ReplaceWith(this HtmlDocument doc, string id, string html)
        {
            doc.GetElementbyId(id).ReplaceWith(html);
        }

        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="html"></param>
        /// <param name="doc"></param>
        public static void ReplaceWithByXpath(this HtmlDocument doc, string xpath, string html)
        {
            doc.DocumentNode.SelectSingleNode(xpath).ReplaceWith(html);
        }

        /// <summary>
        ///     node替换
        /// </summary>
        public static void ReplaceWithValue(this HtmlDocument doc, string id)
        {
            doc.GetElementbyId(id).ReplaceWithValue();
        }

        /// <summary>
        ///     node替换
        /// </summary>
        public static void ReplaceWithValueByXpath(this HtmlDocument doc, string xpath)
        {
            doc.DocumentNode.SelectSingleNode(xpath).ReplaceWithValue();
        }

        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="doc"></param>
        public static void ReplaceWithValue4Select(this HtmlDocument doc, string id, string attributeName)
        {
            doc.GetElementbyId(id).ReplaceWithValue4Select(attributeName);
        }

        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="attributeName"></param>
        /// <param name="doc"></param>
        public static void ReplaceWithValue4SelectByXpath(this HtmlDocument doc, string xpath, string attributeName)
        {
            doc.DocumentNode.SelectSingleNode(xpath).ReplaceWithValue4Select(attributeName);
        }

        /// <summary>
        ///     禁用控件
        /// </summary>
        public static void Disable(this HtmlDocument doc, params string[] ids)
        {
            foreach (var id in ids)
            {
                doc.GetElementbyId(id).Disable();
            }
        }

        /// <summary>
        ///     禁用控件
        /// </summary>
        public static void DisableByXpath(this HtmlDocument doc, params string[] xpaths)
        {
            foreach (var xpath in xpaths)
            {
                doc.DocumentNode.SelectSingleNode(xpath).Disable();
            }
        }
    }
}