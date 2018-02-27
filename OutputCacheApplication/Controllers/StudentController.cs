using OutputCacheApplication.Models;
using System.Linq;
using System.Web.Mvc;

namespace OutputCacheApplication.Controllers
{
    public class StudentController : Controller
    {
        //Location  :  where we want to cache the data on server,or on client
        //OutputCache filter adds an appropriate cache control header in response, which is based upon Location property.
        //VaryByParam property creates a different cache, which is based upon the parameter value and is passed through Query String or Request.Form.
        //CacheProfile - If we want to have same type of OutputCache properties on multiple Action method or multiple controller, then we can use CacheProfile property
        //[OutputCache(Duration = 10,VaryByParam = "none",Location = System.Web.UI.OutputCacheLocation.Server)]
        [OutputCache(CacheProfile = "CacheFor20Seconds")]
        public ActionResult Index()
        {
            using (var dbContext = new SchoolEntities())
            {
                var students = dbContext.Students.ToList();
                return View(students);
            }
        }
    }
}