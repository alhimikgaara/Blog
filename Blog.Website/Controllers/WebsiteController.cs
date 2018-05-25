using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Blog.Common.Constants;
using Newtonsoft.Json;

namespace Blog.Website.Controllers
{
    public class Columns
    {
        public List<string> controllernames { get; set; }
        public List<string> actionnames { get; set; }
    }

    public class RootObject
    {
        public Columns columns { get; set; }
    }
    public class WebsiteController : Controller
    {
        private readonly Assembly _assembly;
        public WebsiteController()
        {
            _assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(t => t.FullName.StartsWith(Namespaces.Services));
        }

        public ActionResult Build()
        {
            string contents;
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString("http://gsx2json.com/api?id=1o4W_TG-td8Rm8zfoqwuGExXc7ECDRTNlfU1CuQZ83Rc&rows=false");

            var model = JsonConvert.DeserializeObject<RootObject>(contents);

            var list = new Dictionary<string, string[]>();

            for (int i = 0; i < model.columns.controllernames.Count; i++)
            {
                list.Add(model.columns.controllernames[i], model.columns.actionnames[i].Split(','));
            }


            var listOfResults = new List<string>();
            
            foreach (var compo in list)
            {
                var type = _assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(compo.Key));
                if (type == null) continue;

                var instance = Activator.CreateInstance(type);

                foreach (var val in compo.Value)
                {
                    var invoked = (JsonResult) type.GetMethod(val).Invoke(instance, null);
                    var serialized = new JavaScriptSerializer().Serialize(invoked.Data);
                    listOfResults.Add(serialized);
                }
            }

            var joined = string.Join(",", listOfResults);

            var format = $@"{"{\"World\": ["}{joined}{"]}"}";
            var format2 = $@"{"["+ format + "]"}";

            var desirialized = new JavaScriptSerializer().Deserialize<object>(format2);
            var pp = Json(desirialized, JsonRequestBehavior.AllowGet);
            return View("ApplicationMain", pp);
        }
    }
}