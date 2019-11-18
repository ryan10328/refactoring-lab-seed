namespace RefactoringLab.Services
{
    public abstract class PriceBase
    {
        public abstract int GetPriceCode();

        public abstract double GetCharge(int daysRented);
    }
}