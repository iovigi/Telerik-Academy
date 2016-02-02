namespace BitCalculator.Controllers
{
    using System.Web.Mvc;
    using BitCalculator.Models;

    public class HomeController : Controller
    {
        public ActionResult Index(CalculatorRequestModel model = null)
        {
            if(model ==null)
            {
                var emptyResponseModel = new CalculatorResponseModel();
                emptyResponseModel.qyantity = 1;
                emptyResponseModel.kilo = 1024;
                emptyResponseModel.delta = 1024 * 8;

                return View(emptyResponseModel);
            }

            var responseModel = new CalculatorResponseModel();

            return View(responseModel);
        }
    }
}