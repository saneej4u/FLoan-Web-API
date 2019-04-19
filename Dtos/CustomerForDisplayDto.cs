using System;
namespace FLoan.System.Web.API.Dtos
{
    public class CustomerForDisplayDto
    {
        public int CustomerId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
    }
}
