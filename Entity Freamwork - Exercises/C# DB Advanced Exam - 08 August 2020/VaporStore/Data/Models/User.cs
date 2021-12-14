﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        //[MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        //[RegularExpression(@"^([A-Z]{1}[a-z]+)\\s([A-Z]{1}[a-z]+)$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        //[Required]
        //[Range(3, 103)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
