﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public Account Account { get; set; }
    }

}
