﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Dtos.User
{
    public record TokenDto(string Token, DateTime ExpirDates);
}
