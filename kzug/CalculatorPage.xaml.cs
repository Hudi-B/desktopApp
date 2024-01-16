using System.Data;
using System.Text;

namespace kzug;

public partial class CalculatorPage : ContentPage
{
    public CalculatorPage()
    {
        InitializeComponent();
    }

    private StringBuilder currentInput = new StringBuilder();

    public void OnButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            string buttonText = button.Text;

            if (buttonText == "=")
            {
                EvaluateExpression();
            }
            else if (buttonText == "C")
            {
                ClearInput();
            }
            else
            {
                currentInput.Append(buttonText);
                UpdateOutput();
            }
        }
    }

    public void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        EvaluateExpression();
    }

    public void OnClearButtonClicked(object sender, EventArgs e)
    {
        ClearInput();
    }

    private void EvaluateExpression()
    {
        try
        {
            if (currentInput.Length > 0)
            {
                string result = EvaluateExpression(currentInput.ToString()).ToString();
                OutputLabel.Text = result;
                currentInput.Clear();
                currentInput.Append(result);
            }
        }
        catch (Exception)
        {
            OutputLabel.Text = "Error";
        }
    }

    private void ClearInput()
    {
        currentInput.Clear();
        UpdateOutput();
    }

    private void UpdateOutput()
    {
        OutputLabel.Text = currentInput.ToString();
    }

    private double EvaluateExpression(string expression)
    {
        return Convert.ToDouble(new DataTable().Compute(expression, string.Empty));
    }
}
