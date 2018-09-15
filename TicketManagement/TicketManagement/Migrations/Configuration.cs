namespace TicketManagement.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TicketManagement.Models;
    using TicketManagement.Services;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketManagement.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketManagement.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //Add content to status table
            context.TicketStatus.AddOrUpdate(new TicketStatus() { Id = 1, Name = "Opened" });
            context.TicketStatus.AddOrUpdate(new TicketStatus() { Id = 2, Name = "Closed" });
            context.TicketStatus.AddOrUpdate(new TicketStatus() { Id = 3, Name = "Answered" });

            //Add content to priority table
            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 1, Name = "High" });
            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 2, Name = "Medium" });
            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 3, Name = "Low" });

            //Add content to category table
            context.TicketCategories.AddOrUpdate(new TicketCategory() { Id = 1, Name = "Category1" });
            context.TicketCategories.AddOrUpdate(new TicketCategory() { Id = 2, Name = "Category2" });
            context.TicketCategories.AddOrUpdate(new TicketCategory() { Id = 3, Name = "Category3" });


            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Create user for test
            var user1 = new ApplicationUser { UserName = "userAdmin1@test.com", Email = "userAdmin1@test.com" };
            if (!context.Users.Any(u => u.UserName == user1.UserName))
            {
                var result1 = userManager.Create(user1, "administrador");
            }else {
                user1 = userManager.FindByEmail(user1.Email);
            }

            var user2 = new ApplicationUser { UserName = "userAdmin2@test.com", Email = "userAdmin2@test.com" };
            if (!context.Users.Any(u => u.UserName == user2.UserName))
            {
                var result2 = userManager.Create(user2, "administrador");
            }
            else
            {
                user2 = userManager.FindByEmail(user2.Email);
            }

            var user3 = new ApplicationUser { UserName = "userAdmin3@test.com", Email = "userAdmin3@test.com" };
            if (!context.Users.Any(u => u.UserName == user3.UserName))
            {
                var result3 = userManager.Create(user3, "administrador");
            }
            else
            {
                user3 = userManager.FindByEmail(user3.Email);
            }

            var user4 = new ApplicationUser { UserName = "userAdmin4@test.com", Email = "userAdmin4@test.com" };
            if (!context.Users.Any(u => u.UserName == user2.UserName))
            {
                var result4 = userManager.Create(user4, "administrador");
            }
            else
            {
                user4 = userManager.FindByEmail(user1.Email);
            }


            //Add ticket for test


            var nuevo = new Ticket() {
                Id = 0,
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user2.Id,
                RecepientID = user3.Id,
                CategoryID = 1,
                PriorityID = 2,
                StatusID = 3
            };
            context.Tickets.AddOrUpdate(nuevo);

            var nuevo1 = new Ticket()
            {
                Id = 1,
                Subject = "This a test ticket",
                CreationDate = new DateTime(2018, 9, 1),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user2.Id,
                RecepientID = user3.Id,
                CategoryID = 1,
                PriorityID = 2,
                StatusID = 3
            };
            context.Tickets.AddOrUpdate(nuevo1);


            var nuevo2 = new Ticket()
            {
                Id = 2,
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user1.Id,
                RecepientID = user2.Id,
                CategoryID = 3,
                PriorityID = 3,
                StatusID = 3
            };
            context.Tickets.AddOrUpdate(nuevo2);

            var nuevo3 = new Ticket()
            {
                Id = 3,
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            };
            context.Tickets.AddOrUpdate(nuevo3);

            
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = new DateTime(2018, 9, 12),
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 3,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = new DateTime(2018, 9, 12),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 3,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });

            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });


            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 3,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test keyWord",
                CreationDate = new DateTime(2018, 9, 1),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 1,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = new DateTime(2018, 9, 12),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 3,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test keyWord",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = new DateTime(2018, 9, 1),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 1,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test keyWord",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = new DateTime(2018, 9, 12),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test keyWord",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });
            context.Tickets.AddOrUpdate(new Ticket()
            {
                Subject = "This a test keyWord",
                CreationDate = new DateTime(2018, 9, 12),
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = user3.Id,
                RecepientID = user4.Id,
                CategoryID = 2,
                PriorityID = 1,
                StatusID = 2
            });




        }

        public void CrearTicKetPrueba(TicketManagement.Models.ApplicationDbContext context)
        {

           
           


        }
    }
}
