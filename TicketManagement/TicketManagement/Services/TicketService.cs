using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using TicketManagement.Models;


namespace TicketManagement.Services
{
    public class TicketService
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly int AmmountOfRecordsByPage = 10;

        public Ticket GetTicketById(int id) {
            Ticket ticket = db.Tickets.Find(id);
            return ticket;
        }

        public List<Ticket> GetTicketsList() {
            var tickets = db.Tickets.Include(t => t.UserAuthor).Include(t => t.UserRecepient).Include(t => t.Category).Include(t => t.Priority).Include(t => t.Status);
            return tickets.ToList();
        }

        public List<Ticket> GetTicketsListByPage(int pageNumber) {
            var tickets = db.Tickets.OrderBy(x => x.Id).Skip((pageNumber - 1) * AmmountOfRecordsByPage).Take(AmmountOfRecordsByPage).Include(t => t.UserAuthor).Include(t => t.UserRecepient).Include(t => t.Category).Include(t => t.Priority).Include(t => t.Status);
            return tickets.ToList();
        }

        public List<Ticket> GetTicketsListByCategoryAndPage(int categoryId, int pageNumber)
        {
            var tickets = db.Tickets.Where(x => x.CategoryID == categoryId).OrderBy(x => x.Id).Skip((pageNumber - 1) * AmmountOfRecordsByPage).Take(AmmountOfRecordsByPage).Include(t => t.UserAuthor).Include(t => t.UserRecepient).Include(t => t.Category).Include(t => t.Priority).Include(t => t.Status);
            return tickets.ToList();
        }

        public List<Ticket> GetTicketsListByCreationDateAndPage(DateTime creationDate, int pageNumber)
        {
            var tickets = db.Tickets.Where(x => DateTime.Compare(x.CreationDate,creationDate)==0 ).OrderBy(x => x.Id).Skip((pageNumber - 1) * AmmountOfRecordsByPage).Take(AmmountOfRecordsByPage).Include(t => t.UserAuthor).Include(t => t.UserRecepient).Include(t => t.Category).Include(t => t.Priority).Include(t => t.Status);
            return tickets.ToList();
        }

        public List<Ticket> GetTicketsListByFilters(int pageNumber, DateTime? creationDate, int? categoryId, string keyWord )
        {
            var tickets = GetTicketsList();
            
            if (creationDate != null) {
                tickets = tickets.Where(x => DateTime.Compare(x.CreationDate, (DateTime)creationDate) == 0).ToList();
             }

            if (categoryId != 0 && categoryId != null) {
                tickets = tickets.Where(x => x.CategoryID == categoryId).ToList();
            }

             if (keyWord != null && !keyWord.Equals("")) {
                tickets = tickets.Where(x => x.Subject.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
             }
             tickets = tickets.OrderBy(x => x.Id).Skip((pageNumber - 1) * AmmountOfRecordsByPage).Take(AmmountOfRecordsByPage).ToList();
             return tickets.ToList();
        }

        public List<Ticket> GetTicketsListByFilters(DateTime? creationDate, int? categoryId, string keyWord)
        {
            var tickets = GetTicketsList();

            if (creationDate != null)
            {
                tickets = tickets.Where(x => DateTime.Compare(x.CreationDate, (DateTime)creationDate) == 0).ToList();
            }

            if (categoryId != 0 && categoryId != null)
            {
                tickets = tickets.Where(x => x.CategoryID == categoryId).ToList();
            }

            if (keyWord != null && !keyWord.Equals(""))
            {
                tickets = tickets.Where(x => x.Subject.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            return tickets.ToList();
        }

        public void CreateNewTicket(Ticket ticket) {
                db.Tickets.Add(ticket);
                db.SaveChanges();
        }


        public void DeleteTicket(int id) {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
        }

        public void EditTicket(Ticket ticket) {
            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<TicketCategory> GetAllCategories() {
            return db.TicketCategories.ToList();

        }

        public List<TicketPriority> GetAllPriorities() {
            return db.TicketPriorities.ToList();
        }

        public List<TicketStatus> GetAllStatus() {
            return db.TicketStatus.ToList();
        }

        public TicketStatus GetStatusById(int id) {
            return db.TicketStatus.Find(id);
        }

        public TicketCategory GetCategoryById(int id) {
            return db.TicketCategories.Find(id);
        } 

        public TicketPriority GetPriorityById(int id) {
            return db.TicketPriorities.Find(id);
        }

        public void CrearTicKetPrueba() {
           
            
            

            ApplicationUser author =GetUserById("2d14e382-1853-4a2e-83b3-619556f3a991");
            ApplicationUser recepient = GetUserById("604f4313-fb74-40bc-8ce4-1ca909ee3f27"); ;
            TicketCategory category = GetCategoryById(1);
            TicketPriority priority = GetPriorityById(1);
            TicketStatus status = GetStatusById(1);
    
            var nuevo = new Ticket()
            {

                Subject = "This a test ticket",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = "2d14e382-1853-4a2e-83b3-619556f3a991",
                RecepientID = "604f4313-fb74-40bc-8ce4-1ca909ee3f27",
                CategoryID=1,
                PriorityID = 1,
                StatusID = 1,
                UserAuthor = author,
                UserRecepient = recepient,
                Category = category,
                Priority = priority,
                Status = status


            };
            CreateNewTicket(nuevo);


        }

        public List<ApplicationUser> GetAllUsers()
        {
            var usersList = db.Users.ToList();
            return usersList;
        }

        public ApplicationUser GetUserById(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser searched = userManager.FindById(userId);
            return searched;
        }

        public ApplicationUser GetUserInformationByMail(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser searched = userManager.FindByEmail(email);
            return searched;
        }

        public void RemoveUser(string userId)
        {
            ApplicationUser user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void EditUser(RegisterViewModel user)
        {
            /* var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
              var userManager = new UserManager<ApplicationUser>(store);
              var currentUser = userManager.FindById(user.UserId);
              currentUser.Name = user.Name;
              currentUser.LastName = user.LastName;
              userManager.Update(currentUser);
              var ctx = store.Context;
              ctx.SaveChanges();*/
        }

        public void CreateNewUser(RegisterViewModel model)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                Console.WriteLine("Se creo bien");
            }
        }

        public bool IsInRole(string email, string role)
        {
            /*ApplicationUser user = db.Users.Where(x => x.Email == email).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            return userManager.IsInRole(user.Id, role);*/
            return true;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}