using Clinic8.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic8.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
          UserManager<IdentityUser> userManger,
          RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            string password = "P@ssw0rd";
            string role1 = "Admin";
            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role1));
            }

            if (await userManger.FindByNameAsync("kamal@gmail.com") == null)
            {

                var user = new IdentityUser { UserName = "kamalsayed", Email = "kamal@gmail.com" };

                var result = await userManger.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var admin = new Admin
                    {

                        admin_email = "kamal@gmail.com",
                        admin_username = "kamalsayed",
                        admin_fname = "kamal",
                        admin_mname = "samir",
                        admin_lname = "sayed",
                        admin_password = password,
                        admin_phone = "8645",
                        Id = user.Id
                    };

                    context.Admin.Add(admin);
                    await context.SaveChangesAsync();
                    await userManger.AddToRoleAsync(user, "Admin");
                }
                  
                

            }

        }
    }
}
