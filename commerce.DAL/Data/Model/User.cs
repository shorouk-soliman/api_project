﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;




namespace commerce.DAL.Data.Model
{
    public class User : IdentityUser
    {
        public ICollection<Order>? orders { get; set; }
        public Cart? cart { get; set; }
    }
}
