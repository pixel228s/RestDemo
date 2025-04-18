﻿namespace PizzaRestaurantDemo.Application.Users.Requests
{
    public class UserAddressUpdateRequest
    {
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
    }
}
