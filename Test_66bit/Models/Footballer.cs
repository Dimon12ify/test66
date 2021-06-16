using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Test_66bit.Models
{
    public class Footballer
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        
        public long TeamId { get; set; }
        public Team Team { get; set; }
        [Required]
        
        public Country Country { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Country
    {
        [Display(Name = "Россия")]
        Russia,
        [Display(Name = "США")]
        Usa,
        [Display(Name = "Италия")]
        Italy
    }
}