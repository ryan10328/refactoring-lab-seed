using System;
using System.Collections.Generic;
using System.Text;
using RefactoringLab.Services;

namespace RefactoringLabTest
{
    public class CustomerBuilder
    {
        public static readonly string Name = "Roberts";
        private string _name = Name;
        private readonly List<Rental> rentals = new List<Rental>();

        public Customer Build()
        {
            var result = new Customer(_name);
            foreach (var rental in rentals)
            {
                result.AddRental(rental);
            }
            return result;
        }

        public CustomerBuilder WithName(string name)
        {
            this._name = name;
            return this;
        }

        public CustomerBuilder WithRentals(params Rental[] rentals)
        {
            this.rentals.AddRange(rentals);
            return this;
        }
    }
}
