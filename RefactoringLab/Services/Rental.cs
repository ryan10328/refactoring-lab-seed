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
        /// <param name="daysRented"></param>
        /// <returns></returns>
        public double GetCharge(int daysRented)
        {
            // 變更變數為 result，表示在這個方法內計算的結果
            double result = 0;
            // determine amounts for rental line
            // 這裡先取得 Movie 並且又呼叫 GetMovie().GetPriceCode() 所以意味著可以把這個方法搬到 Movie.cs
            // 並且在 switch case 當中 result 為區域變數(不影響)，所以只有 GetDaysRented() 這個東西需要改成從 Function 外傳入
            // 1. 先抽取 GetDaysRented() 變成 parameter 傳入
            // 2. 把方法推到 Movie.cs 當中
            switch (this.GetMovie().GetPriceCode())
            {
                case Movie.Regular:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    result += daysRented * 3;
                    break;
                case Movie.Children:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;
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