namespace BitCalculator.Controllers
{
    using System.Web.Mvc;
    using BitCalculator.Models;

    public class HomeController : Controller
    {
        public ActionResult Index(CalculatorRequestModel model = null)
        {
            if (model == null)
            {
                var emptyResponseModel = new CalculatorResponseModel();

                return View(emptyResponseModel);
            }

            var responseModel = new CalculatorResponseModel();
            responseModel.Kilo = model.Kilo;
            responseModel.Bits = model.Type.GetBits(model.Qyantity, model.Kilo);

            return View(responseModel);
        }
    }
}