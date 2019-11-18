namespace RefactoringLab.Services
{
    public class NewReleasePrice : PriceBase
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 0;
            result += daysRented * 3;
            return result;
        }
    }
}