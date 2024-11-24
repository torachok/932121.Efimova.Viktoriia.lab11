using lab11.Models;

public class CalcService
{
    public CalcServiceModel Calculate(int firstValue, int secondValue)
    {
        return new CalcServiceModel
        {
            FirstValue = firstValue,
            SecondValue = secondValue,
            Add = firstValue + secondValue,
            Sub = firstValue - secondValue,
            Mult = firstValue * secondValue,
            Div = secondValue != 0 ? (double?)(firstValue / secondValue) : null
        };
    }
}