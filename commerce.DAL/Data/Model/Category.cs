﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Data.Model
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}
