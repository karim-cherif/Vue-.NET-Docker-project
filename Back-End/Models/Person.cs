namespace Back_End.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Address { get; set; } = string.Empty; 
                
    }
}
