using System;
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
            string admin = "dima@gmail.com";
            string password = "_Hum45678";
            if (await userManager.FindByEmailAsync(admin) == null)
            {
                Employee employee = new Employee { Email = admin, UserName = admin, EmailConfirmed = true, Name = "Dmitriy", Surname = "Senkos" };
                IdentityResult result = await userManager.CreateAsync(employee, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Admin");
                }
            }
        }
    }
}
