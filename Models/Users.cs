using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesUser.Models
{
    public class User
    {
        public int ID { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string? Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string? FirstName { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string? LastName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthDate { get; set; }
    }
}