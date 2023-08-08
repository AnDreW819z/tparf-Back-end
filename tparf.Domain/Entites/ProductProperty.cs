﻿using System.ComponentModel.DataAnnotations;

namespace tparf.Domain.Entites
{
    public class ProductProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
