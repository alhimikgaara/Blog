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
    public class WebsiteController : Controller
    {
        private readonly Assembly _assembly;
        public WebsiteController()
        {
            _assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(t => t.FullName.StartsWith(Namespaces.Services));
        }

        public ActionResult Build(Dictionary<string,List<string>> list)
        {
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
            var format2 = $@"{"[{\"componentName\": \"AppContainer\", \"data\": { \"isEditorMode\": false},\"nestedComponents\": "+ format + "}]"}";



            var desirialized = new JavaScriptSerializer().Deserialize<object>(format2);

            var pp = Json(desirialized, JsonRequestBehavior.AllowGet);

            var tt = JsonConvert.SerializeObject(pp.Data);
            //return Json(desirialized, JsonRequestBehavior.AllowGet);
            return View("About", pp);
        }
    }
}