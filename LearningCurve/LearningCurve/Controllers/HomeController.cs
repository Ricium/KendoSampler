using LearningCurve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCurve.Common;

namespace LearningCurve.Controllers
{
    public class HomeController : Controller
    {
        private int count = 10;
        public ActionResult Index()
        {
            return View();
        }  
        
        public JsonResult GetData()
        {
            var list = new List<GridData>();
            for (int i = 1; i < 11; i++)
            {
                var item = new GridData()
                {
                    ID = i,
                    ForeignKeyField = 1,
                    TextField = string.Format("Item {0}", i.ToString())
                };
                list.Add(item);
            }

            IEnumerable<GridData> result = list;

            return this.Jsonp(result);
        }    
        
        public JsonResult Create()
        {
            var models = this.DeserializeObject<IEnumerable<GridData>>("models");
            if (models != null)
            {
                //...Temp - illustrate save
                count++;
                models.FirstOrDefault().ID = count;

                //...If you get more than one object, means the previous save didn't commit. 
                //...Probably didnt change the ID
            }
            return this.Jsonp(models);
        }

        public JsonResult Update()
        {
            var models = this.DeserializeObject<IEnumerable<GridData>>("models");
            if (models != null)
            {
                
            }
            return this.Jsonp(models);
        }

        public JsonResult Destroy()
        {
            var models = this.DeserializeObject<IEnumerable<GridData>>("models");

            if (models != null)
            {
            }

            return this.Jsonp(models);
        }
    }
}