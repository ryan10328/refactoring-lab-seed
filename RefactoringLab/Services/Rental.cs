namespace RefactoringLab.Services
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public Movie Movie
        {
            get { return _movie; }
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public int GetFrequentRenterPoints()
        {
            int frequentRenterPoints = 0;
            // add frequent renter points
            frequentRenterPoints++;
            // add bonus for a two day new release rental
            if ((this.GetMovie().GetPriceCode() == Movie.NewRelease) && this.GetDaysRented() > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }
    }
}