namespace RefactoringLab.Services
{
    public class RegularPrice : PriceBase
    {
        public override int GetPriceCode()
        {
            return (int)PriceCode.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 0;
            result += 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;

            return result;
        }
    }
}