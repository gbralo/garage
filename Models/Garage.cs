namespace BikeGarageAPI.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;    

        public string Country { get; set; } = string.Empty;  
        public string Location { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } 

    }
}
