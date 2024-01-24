using KsiegarniaPKP.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaPKP.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<Uzytkownik> userManager,
                  RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        // name - correct email
        // password - min 8 charcters, small and capital letter, digit and special char
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Uzytkownik").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Uzytkownik",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Kurier").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Kurier",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Pracownik").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Pracownik",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

        }

        public static void SeedOneUser(UserManager<Uzytkownik> userManager,
                                        string email, string password, string imie, string nazwisko, string role = null)
        {
            string name = imie + "-" + nazwisko;
            if (userManager.FindByNameAsync(name).Result == null)
            {
                string id = imie + nazwisko + "_" + email;
                Uzytkownik user = new Uzytkownik
                {
                    Id = id,
                    Imie = imie,
                    Nazwisko = nazwisko,
                    UserName = name, 
                    Email = email
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<Uzytkownik> userManager)
        {
            Constants c = new Constants();
            SeedOneUser(userManager, c.emaile[0], c.hasla[0], c.imiona[0], c.nazwiska[0], c.role[0]);
            SeedOneUser(userManager, c.emaile[1], c.hasla[1], c.imiona[1], c.nazwiska[1], c.role[1]);
            SeedOneUser(userManager, c.emaile[2], c.hasla[2], c.imiona[2], c.nazwiska[2], c.role[2]);
            SeedOneUser(userManager, c.emaile[3], c.hasla[3], c.imiona[3], c.nazwiska[3], c.role[3]);
        }
    }


}
