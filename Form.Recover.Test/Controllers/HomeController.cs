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
            html = doc.DocumentNode.WriteTo();

            Session["html"] = html;
            return new EmptyResult();
        }

        public ActionResult Recover()
        {
            return View();
        }
    }
}