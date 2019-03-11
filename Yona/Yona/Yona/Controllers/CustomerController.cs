using System.Linq;
using System.Web.Mvc;
using Yona.Data;
using Yona.Models;

namespace Yona.Controllers
{
    public class CustomerController : Controller
    {
        private Context db = new Context();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetProducts(DTParameters param)
        {
            var query = db.Products.AsQueryable();
            var totalCount = query.Count();

            if (!string.IsNullOrEmpty(param.Search.Value))
            {//where
                var value = param.Search.Value.Trim();
                query = query.Where(x => x.Title.Contains(value));
            }

            var filteredCount = query.Count();
            var products = query.OrderBy(x => x.Title)
                                .Skip(param.Start)
                                .Take(param.Length)
                                .ToList();

            var result = new DTResult<Product>
            {
                draw = param.Draw,
                data = products,
                recordsFiltered = filteredCount,
                recordsTotal = totalCount
            };
            return Json(result);
        }
    }
}