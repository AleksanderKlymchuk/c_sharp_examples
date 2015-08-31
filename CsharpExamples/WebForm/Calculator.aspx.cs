using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Calculator : System.Web.UI.Page
    {
        CalculatorRef.cs.calculatorSoapClient calculator;
        protected void Page_Load(object sender, EventArgs e)
        {
           calculator  = new CalculatorRef.cs.calculatorSoapClient();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           result.Text= calculator.Add(Convert.ToInt32(firstNumber.Text), Convert.ToInt32(lastNumber.Text)).ToString();
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
           result.Text= calculator.Substract(Convert.ToInt32(firstNumber.Text), Convert.ToInt32(lastNumber.Text)).ToString();
        }

        protected void btnMul_Click(object sender, EventArgs e)
        {
           result.Text= calculator.Multiple(Convert.ToInt32(firstNumber.Text), Convert.ToInt32(lastNumber.Text)).ToString();
        }

        protected void btnDev_Click(object sender, EventArgs e)
        {
          result.Text=  calculator.Divide(Convert.ToInt32(firstNumber.Text), Convert.ToInt32(lastNumber.Text)).ToString();
        }
    }
}