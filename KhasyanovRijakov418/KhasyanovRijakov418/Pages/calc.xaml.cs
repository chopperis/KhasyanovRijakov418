using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KhasyanovRijakov418.Pages
{
    /// <summary>
    /// Логика взаимодействия для calc.xaml
    /// </summary>
    public partial class calc : Page
    {
        string leftop = ""; 
        string operation = ""; 
        string rightop = ""; 
        public calc()
        {
 
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            if (s == "x^2") {
                string b = s;
                char[] MyChar = { 'x' };
                string NewString = b.TrimStart(MyChar);
                s = NewString;
            }
            else if (s == "√x" || s == "1/x" || s == "10^x")
            {
                string b = s;
                char[] MyChar = { 'x' };
                string NewString = b.TrimEnd(MyChar);
                s = NewString;
            }
            textBlock.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);
            if (result == true)
            {
                if (operation == "")
                {
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                }
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
               
            }
        }
        private void Update_RightOp()
        {
            double num1 = 0;
            if (leftop != "")
            {
                num1 = Int32.Parse(leftop);
            }
            double num2 = 0;
            if (rightop != "") {
                num2 = Int32.Parse(rightop);
            }

            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
                case "^2":
                    rightop = Math.Pow(num1, 2).ToString();
                    break;
                case "√":
                    rightop = Math.Sqrt(num2).ToString();
                    break;
                case "1/":
                    if (num2 != 0)
                        rightop = Math.Round(1 / num2, 2).ToString();
                    else
                        rightop = "На ноль делить нельзя!!!";
                    break;
                case "10^":
                    rightop = Math.Pow(10, num2).ToString();
                    break;
            }
        }
    }
}