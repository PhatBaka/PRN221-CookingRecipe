using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

#nullable disable

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public Customer(string name, string email, string city, string country, string password, DateTime date)
        {
            CustomerName = name;
            Email = email;
            City = city;
            Country = country;
            Password = password;
            Birthday = date.Date;
        }

        public int CustomerId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
