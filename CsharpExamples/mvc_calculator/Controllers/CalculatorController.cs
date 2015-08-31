using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace mvc_calculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        [HttpGet]
        public ActionResult Index()
        {
            return View(new calculator());
        }
        [HttpPost]
        public ActionResult Index(calculator cal,string sign)
        {
            CalculatorRef.calculatorSoapClient client = new CalculatorRef.calculatorSoapClient();   
            switch (sign)
            {
                case "+":
                    cal.sum= client.Add(cal.firstNumber, cal.lastNumber);
                    break;
                case "-":
                    cal.sum = client.Substract(cal.firstNumber, cal.lastNumber);
                    break;
                case "*":
                    cal.sum = client.Multiple(cal.firstNumber, cal.lastNumber);
                    break;
                case "/":
                    cal.sum = client.Divide(cal.firstNumber, cal.lastNumber);
                    break;

            }
            return View(cal);
        }
    }
}