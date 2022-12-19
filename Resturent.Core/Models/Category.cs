﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required,MaxLength(150)]
        public string Name { get; set; }

        public virtual List<Meal> Meals { get; set; }
    }
}
