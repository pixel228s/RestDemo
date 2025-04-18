namespace PizzaRestaurantDemo.Domain.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
