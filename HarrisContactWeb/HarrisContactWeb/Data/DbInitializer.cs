﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisContactWeb.Data
{
    public class DbInitializer
    {
        public static void Intialize(HarrisDbContext context)
        {
            //Making sure the database was created correctly with the right context
            context.Database.EnsureCreated();
        }
    }
}
