using Microsoft.Maui.Controls;
using System;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        // TODO: Key inputs
        // TODO: decimal button
        // TODO: Organize layout to reflect common calculator layouts

        double firstNumber, secondNumber;
        string operatorClicked;
        bool isOperatorClicked;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (ResultEntry.Text == "0" || isOperatorClicked)
            {
                ResultEntry.Text = button.Text;
                isOperatorClicked = false;
            }
            else
            {
                ResultEntry.Text += button.Text;
            }
        }

        void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            isOperatorClicked = true;
            operatorClicked = button.Text;
            firstNumber = Convert.ToDouble(ResultEntry.Text);
        }

        void OnClearButtonClicked(object sender, EventArgs e)
        {
            ResultEntry.Text = "0";
            firstNumber = secondNumber = 0;
            isOperatorClicked = false;
        }

        void OnEqualButtonClicked(object sender, EventArgs e)
        {
            secondNumber = Convert.ToDouble(ResultEntry.Text);

            double result = 0;
            switch (operatorClicked)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }

            ResultEntry.Text = result.ToString();
            isOperatorClicked = false;
        }

        void OnPointerEntered(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Color.FromArgb("#ADD8E6"); // Light blue color
        }

        void OnPointerExited(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Colors.LightGray;  // Back to the chosen default light gray
        }
    }
}
