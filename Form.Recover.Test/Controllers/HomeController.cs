using System.Web.Mvc;

using HtmlAgilityPack;

using Newtonsoft.Json.Linq;

namespace Form.Recover.Test.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ValidateRequest = false;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(string data, string html)
        {
            var jObject = JObject.Parse(data);
            html = "<!DOCTYPE html>" + html;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            doc.SetText("textId1", jObject);
            doc.SetText<double>("textId2", jObject);
            doc.SetCheckbox("checkboxId", jObject);
            doc.SetRadiobox("radioId1", jObject, "radioId1", "radioId2");
            doc.SetSelect("selectId", jObject);
            doc.SetTextarea("textereaId", jObject);
            doc.SetRadiobox(jObject, "radioValue", "radioId3", "radioId4", "radioId5");
            html = doc.DocumentNode.WriteTo();

            doc.ReplaceWithValue("textId1");
            doc.ReplaceWithValue("textId2");
            doc.Disable("checkboxID");
            doc.Disable("radioId1", "radioId2");
            doc.ReplaceWithValue4Select("selectId", "text");
            doc.ReplaceWithValue("textereaId");
            doc.Disable("radioId3", "radioId4", "radioId5");
            var htmlReadOnly = doc.DocumentNode.WriteTo();

            Session["html"] = html;
            Session["htmlReadOnly"] = htmlReadOnly;
            return new EmptyResult();
        }

        public ActionResult Recover()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}