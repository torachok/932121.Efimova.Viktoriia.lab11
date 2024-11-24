using lab11.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab11.Controllers
{
    public class CalcServiceController : Controller
    {
        public IActionResult PassUsingModel()
        {
            var model = new CalcServiceModel
            {
                FirstValue = new Random().Next(0, 11),
                SecondValue = new Random().Next(0, 11)
            };

            model.Add = model.FirstValue + model.SecondValue;
            model.Sub = model.FirstValue - model.SecondValue;
            model.Mult = model.FirstValue * model.SecondValue;
            model.Div = model.SecondValue != 0 ? (double?)(model.FirstValue / model.SecondValue) : null;

            return View(model);
        }
        public IActionResult PassUsingViewData()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            ViewData["FirstValue"] = firstValue;
            ViewData["SecondValue"] = secondValue;
            ViewData["Add"] = firstValue + secondValue;
            ViewData["Sub"] = firstValue - secondValue;
            ViewData["Mult"] = firstValue * secondValue;
            ViewData["Div"] = secondValue != 0 ? (double?)(firstValue / secondValue) : null;

            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            ViewBag.FirstValue = firstValue;
            ViewBag.SecondValue = secondValue;
            ViewBag.Add = firstValue + secondValue;
            ViewBag.Sub = firstValue - secondValue;
            ViewBag.Mult = firstValue * secondValue;
            ViewBag.Div = secondValue != 0 ? (double?)(firstValue / secondValue) : null;
            return View();
        }

        private readonly CalcService _calcService;

        public CalcServiceController(CalcService calcService)
        {
            _calcService = calcService; 
        }

        public IActionResult AccessServiceDirectly()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            var model = _calcService.Calculate(firstValue, secondValue); // Use the service to perform calculations

            return View(model);
        }
    }
}
