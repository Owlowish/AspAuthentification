using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Authentification.Models
{

    public static class SeedUser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserContext (
                serviceProvider.GetRequiredService<
                DbContextOptions<UserContext>>()))
            {
                //loook for any users

                if (context.User.Any())
                {
                    return; //DB has been seeded
                }

                context.User.AddRange(

                    new User{
                        
                        UserNumber = "1111",
                        Password = "1111",
                        FirstName = "Yuhan",
                        FamilyName = "Chen",
                    },

                      new User{
                        
                        UserNumber = "2222",
                        Password = "2222",
                        FirstName = "Hugo",
                        FamilyName = "Ruellet",
                    },

                        new User{
                        
                        UserNumber = "3333",
                        Password = "3333",
                        FirstName = "Winnie",
                        FamilyName = "L'ourson",
                    }


                );
                context.SaveChanges();
            }    
            
        }
    }
    
}