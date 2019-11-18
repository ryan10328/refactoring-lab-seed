namespace RefactoringLab.Services
{
    public class Rental
    {
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            _daysRented = daysRented;
        }

        public Movie Movie { get; }

        public double GetCharge()
        {
            return Movie.GetCharge(_daysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(_daysRented);
        }
    }
}