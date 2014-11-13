using System.Linq;

using Bootstrap.Pagination;

using HtmlAgilityPack;

using Newtonsoft.Json.Linq;

namespace Form.Recover
{
    /// <summary>
    ///     HtmlNode的扩展
    /// </summary>
    public static class HtmlNodeExtension
    {
        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="node"></param>
        /// <param name="html"></param>
        public static void ReplaceWith(this HtmlNode node, string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                node.ParentNode.InsertAfter(HtmlNode.CreateNode(html), node);
            }
            node.Remove();
        }

        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="node"></param>
        public static void ReplaceWithValue(this HtmlNode node)
        {
            var attribute = node.Attributes.FirstOrDefault(a => a.Name == "value");
            if (attribute != null)
            {
                node.ReplaceWith(attribute.Value);
            }
            else
            {
                node.Remove();
            }
        }

        /// <summary>
        ///     node替换
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        public static void ReplaceWithValue4Select(this HtmlNode node, string attributeName)
        {
            foreach (var childNode in node.ChildNodes)
            {
                if (childNode.GetAttributeValue("selected", "") == "selected")
                {
                    node.ReplaceWith(childNode.GetAttributeValue(attributeName, ""));
                    return;
                }
            }
            node.Remove();
        }

        /// <summary>
        ///     禁用控件
        /// </summary>
        /// <param name="node"></param>
        public static void Disable(this HtmlNode node)
        {
            node.SetAttributeValue("disabled", "disabled");
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetText(this HtmlNode node, JToken jToken, string name)
        {
            node.SetAttributeValue("value", jToken.Get(name));
        }

        /// <summary>
        ///     设置Text Input的value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetText<T>(this HtmlNode node, JToken jToken, string name)
        {
            node.SetAttributeValue("value", jToken.Get<T>(name).ToString());
        }

        /// <summary>
        ///     设置Select的当前选中项
        /// </summary>
        /// <param name="node"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetSelect(this HtmlNode node, JToken jToken, string name)
        {
            if (jToken[name] == null)
            {
                return;
            }
            var value = jToken.Get(name);
            foreach (var childNode in node.ChildNodes)
            {
                if (childNode.GetAttributeValue("value", "") == value)
                {
                    childNode.SetAttributeValue("selected", "selected");
                }
                else
                {
                    var attribute = childNode.Attributes.FirstOrDefault(a => a.Name == "selected");
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
        /// <param name="node"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetCheckbox(this HtmlNode node, JToken jToken, string name)
        {
            var isChecked = jToken.Get<bool>(name);
            if (isChecked)
            {
                node.SetAttributeValue("checked", "checked");
            }
            else
            {
                var attribute = node.Attributes.FirstOrDefault(a => a.Name == "checked");
                if (attribute != null)
                {
                    attribute.Remove();
                }
            }
        }

        /// <summary>
        ///     设置两个Radiobox Input的选中状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        /// <param name="anotherNode"></param>
        public static void SetRadiobox(this HtmlNode node, JToken jToken, string name, HtmlNode anotherNode)
        {
            var isChecked = jToken.Get<bool>(name);
            if (isChecked)
            {
                node.SetAttributeValue("checked", "checked");
                var attribute = anotherNode.Attributes.FirstOrDefault(a => a.Name == "checked");
                if (attribute != null)
                {
                    attribute.Remove();
                }
            }
            else
            {
                node.SetAttributeValue("checked", "checked");
                var attribute = anotherNode.Attributes.FirstOrDefault(a => a.Name == "checked");
                if (attribute != null)
                {
                    attribute.Remove();
                }
            }
        }

        /// <summary>
        ///     设置Radiobox Input的选中状态
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        /// <param name="nodes"></param>
        public static void SetRadiobox(this HtmlNode[] nodes, JToken jToken, string name)
        {
            var value = jToken.Get(name);
            foreach (var node in nodes)
            {
                var valueAttr = node.Attributes.FirstOrDefault(a => a.Name == "value");
                if (valueAttr != null)
                {
                    if (valueAttr.Value == value)
                    {
                        node.SetAttributeValue("checked", "checked");
                        continue;
                    }
                }
                var checkedAttr = node.Attributes.FirstOrDefault(a => a.Name == "value");
                if (checkedAttr != null)
                {
                    checkedAttr.Remove();
                }
            }
        }

        /// <summary>
        ///     设置Textarea的value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="jToken"></param>
        /// <param name="name"></param>
        public static void SetTextarea(this HtmlNode node, JToken jToken, string name)
        {
            node.InnerHtml = jToken.Get(name);
        }
    }
}