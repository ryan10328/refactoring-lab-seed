using System;
using System.Text;

namespace RefactoringLab.Services
{
    public abstract class PriceBase
    {
        public abstract int GetPriceCode();
    }

    public class ChildrenPrice : PriceBase
    {
        public override int GetPriceCode()
        {
            return Movie.Children;
        }
    }

    public class NewReleasePrice : PriceBase
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }
    }
    public class RegularPrice : PriceBase
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }
    }



    public class Movie
    {
        public const int Children = 2;
        public const int NewRelease = 1;
        public const int Regular = 0;

        private readonly string _title;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            SetPriceCode(priceCode);
        }

        public int GetPriceCode()
        {
            return _priceCode;
        }

        public void SetPriceCode(int priceCode)
        {
            _priceCode = priceCode;
        }
        public string GetTitle()
        {
            return _title;
        }

        /// <summary>
        /// 抽取出此 Method，原因是因為 Method 內部並沒有使用到其他類別的內容 (除了 Movie 之外)，且 thisAmount 為區域變數
        /// 因為上述原因，所以將此方法推至 Rental 類別中
        /// </summary>
        /// <param name="daysRented"></param>
        /// <returns></returns>
        public double GetCharge(int daysRented)
        {
            double result = 0;
            
            // 這邊看到他先呼叫 rental 才又呼叫面的 Movie，但因為我們目前其實已經在 Movie 類別
            // 表示其實根本不需要透過 rental 來取得 PriceCode，所以可以把 rental 參數 safe delete
            switch (GetPriceCode())
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

        public int GetFrequentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 0;
            // add frequent renter points
            frequentRenterPoints++;
            // add bonus for a two day new release rental
            if ((GetPriceCode() == Movie.NewRelease) && daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }
    }
}
