namespace RefactoringLab.Services
{
    public class ChildrenPrice : PriceBase
    {
        public override int GetPriceCode()
        {
            return Movie.Children;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 0;
            result += 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}