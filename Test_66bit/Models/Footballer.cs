using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Test_66bit.Models
{
    public class Footballer
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Team { get; set; }
        
        public Country Country { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Country
    {
        Russia,
        Usa,
        Italy
    }
}