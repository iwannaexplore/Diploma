﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Models;
using Microsoft.AspNetCore.Identity;

namespace Diploma
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<Employee> userManager)
        {
            string adminEmail = "julie@gmail.com";
            string password = "_Aa123456";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                Employee admin = new Employee { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true, Name = "Julie", Surname = "Smirnova", StartDateOfWork = DateTime.Now.AddMonths(-2), EndDateOfWork = DateTime.Now.AddDays(5), Salary = 10M};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            string userEmail = "dima@gmail.com";
            string userPassword = "_Hum45678";
            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                Employee user = new Employee { Email = userEmail, UserName = userEmail, EmailConfirmed = true, Name = "Dima", Surname = "Senko", StartDateOfWork = DateTime.Now.AddMonths(-25), EndDateOfWork = DateTime.Now.AddDays(25), Salary = 10M };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

        }
    }
}