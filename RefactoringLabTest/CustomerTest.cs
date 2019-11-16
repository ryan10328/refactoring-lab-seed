using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringLab.Services;

namespace RefactoringLabTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            var c = new CustomerBuilder().Build();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestAddRental()
        {
            var customer2 = new CustomerBuilder().WithName("Julia").Build();
            var movie1 = new Movie("Gone with the Wind", Movie.Regular);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            var c = new Customer("David");
            Assert.AreEqual("David", c.GetName());
        }
        [TestMethod]
        public void StatementForRegularMovie()
        {
            var movie1 = new Movie("Gone with the Wind", Movie.Regular);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            var customer2 =
                    new CustomerBuilder()
                            .WithName("Sallie")
                            .WithRentals(rental1)
                            .Build();
            var expected = "Rental Record for Sallie\n" +
                    "\tGone with the Wind\t3.5\n" +
                    "Amount owed is 3.5\n" +
                    "You earned 1 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForNewReleaseMovie()
        {
            var movie1 = new Movie("Star Wars", Movie.NewRelease);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2 =
                    new CustomerBuilder()
                            .WithName("Sallie")
                            .WithRentals(rental1)
                            .Build();
            var expected = "Rental Record for Sallie\n" +
                    "\tStar Wars\t9\n" +
                    "Amount owed is 9\n" +
                    "You earned 2 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForChildrensMovie()
        {
            var movie1 = new Movie("Madagascar", Movie.Children);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            var customer2
                    = new CustomerBuilder()
                    .WithName("Sallie")
                    .WithRentals(rental1)
                    .Build();
            var expected = "Rental Record for Sallie\n" +
                    "\tMadagascar\t1.5\n" +
                    "Amount owed is 1.5\n" +
                    "You earned 1 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForManyMovies()
        {
            var movie1 = new Movie("Madagascar", Movie.Children);
            var rental1 = new Rental(movie1, 6); // 6 day rental
            var movie2 = new Movie("Star Wars", Movie.NewRelease);
            var rental2 = new Rental(movie2, 2); // 2 day rental
            var movie3 = new Movie("Gone with the Wind", Movie.Regular);
            var rental3 = new Rental(movie3, 8); // 8 day rental
            var customer1
                    = new CustomerBuilder()
                    .WithName("David")
                    .WithRentals(rental1, rental2, rental3)
                    .Build();
            var expected = "Rental Record for David\n" +
                    "\tMadagascar\t6\n" +
                    "\tStar Wars\t6\n" +
                    "\tGone with the Wind\t11\n" +
                    "Amount owed is 23\n" +
                    "You earned 4 frequent renter points";
            string statement = customer1.Statement();
            Assert.AreEqual(expected, statement);
        }

        //TODO make test for price breaks in code.
    }

}
