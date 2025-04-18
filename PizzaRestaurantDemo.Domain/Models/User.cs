﻿using PizzaRestaurantDemo.Domain.Base;

namespace PizzaRestaurantDemo.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        //public int? AddressId {  get; set; } 
        public Address? Address { get; set; }    
        public List<Order> Orders { get; set; } = new();
        public List<RankHistory> Ranks { get; set; } = new();
    }
}
