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

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        /// <summary>
        /// 抽取出此 Method，原因是因為 Method 內部並沒有使用到其他類別的內容 (除了 Movie 之外)，且 thisAmount 為區域變數
        /// 因為上述原因，所以將此方法推至 Rental 類別中
        /// </summary>
        /// <returns></returns>
        public double AmountForRental()
        {
            // 變更變數為 result，表示在這個方法內計算的結果
            double result = 0;
            // determine amounts for rental line
            switch (this.GetMovie().GetPriceCode())
            {
                case Movie.Regular:
                    result += 2;
                    if (this.GetDaysRented() > 2)
                        result += (this.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    result += this.GetDaysRented() * 3;
                    break;
                case Movie.Children:
                    result += 1.5;
                    if (this.GetDaysRented() > 3)
                        result += (this.GetDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}