using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using DoubleConverter;
using DoubleConverterWeb.Models;

namespace DoubleConverterWeb.Controllers
{
    public class DoubleTransformController : Controller
    {
        // GET: DoubleTransform
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(string inputDouble, string TransformOptions)
        {
            inputDouble = inputDouble.Replace(',','.');
            DoubleTransformModel model = new DoubleTransformModel();
            double input;

            bool isDouble = double.TryParse(inputDouble, NumberStyles.Any, CultureInfo.InvariantCulture, out input);
            if(!isDouble)
            {
                return View();
            }

            model.InputValue = input;
            string result;
            if (TransformOptions=="Get IEEE format")
            {
                result = model.InputValue.GetIEEEBinaryString();               
            }
            else
            {
                model.IsGetIEEE = false;
                result = Transformer.TransformToWords(model.InputValue);
            }

            ViewBag.Result = result;
            return View(model);
        }

    }
}