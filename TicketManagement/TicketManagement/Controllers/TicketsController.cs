﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketManagement.Models;
using TicketManagement.Services;
using Microsoft.AspNet.Identity;

namespace TicketManagement.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private TicketService ticketService = new TicketService();

        // GET: Tickets
        public ActionResult Index(string keywordFilter,DateTime? creationDateFilter, int? categoryFilter, int pageNumber = 1)
        {
            var tickets = ticketService.GetTicketsListByFilters(pageNumber, creationDateFilter, categoryFilter, keywordFilter);
            //var tickets2 = ticketService.GetTicketsList();  //var tickets = ticketService.GetTicketsListByPage(pageNumber);
               List <SelectListItem> categoriesSelect = new List<SelectListItem>();
               var categories = ticketService.GetAllCategories();
               foreach (var category in categories)
               {
                   categoriesSelect.Add(new SelectListItem() { Text = category.Name, Value = "" + category.Id });
               }
                categoriesSelect.Add(new SelectListItem() { Text = "All Categories", Value = "0",Selected=true
                });
                ViewBag.CategoriesList = categoriesSelect;


               var model = new TicketViewModel();
            model.Tickets = tickets;
            model.CurrentPage = pageNumber;
            model.AmmountOfRecords = ticketService.GetTicketsListByFilters(creationDateFilter, categoryFilter, keywordFilter).Count();
            model.RecordsByPage = 10;
            return View(model);
        }

        public ActionResult IndexV1(int pageNumber = 1)
        {
            var tickets = ticketService.GetTicketsListByPage(pageNumber);
            List<SelectListItem> categoriesSelect = new List<SelectListItem>();
            var categories = ticketService.GetAllCategories();
            foreach (var category in categories) {
                categoriesSelect.Add(new SelectListItem() { Text = category.Name, Value = ""+category.Id });
            }
            ViewBag.CategoriesList = categoriesSelect;

            return View(tickets);
        }

        public ActionResult EditTicket(int id)
        {
            Ticket ticket = ticketService.GetTicketById(id);

            List<SelectListItem> categoriesSelect = new List<SelectListItem>();
            var categories = ticketService.GetAllCategories();
            foreach (var category in categories)
            {
                categoriesSelect.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = "" + category.Id,
                    Selected = category.Id == ticket.CategoryID ? true : false
                });
            }

            List<SelectListItem> statusSelect = new List<SelectListItem>();
            var statusList = ticketService.GetAllStatus();
            foreach (var status in statusList)
            {
                statusSelect.Add(new SelectListItem() {
                    Text = status.Name,
                    Value = "" + status.Id,
                    Selected = status.Id == ticket.StatusID ? true : false
                });
            }

            List<SelectListItem> prioritiesSelect = new List<SelectListItem>();
            var priorities = ticketService.GetAllPriorities();
            foreach (var priority in priorities)
            {
                prioritiesSelect.Add(new SelectListItem() {
                    Text = priority.Name,
                    Value = "" + priority.Id,
                    Selected = priority.Id == ticket.PriorityID ? true : false
                });
            }

            List<SelectListItem> usersSelect = new List<SelectListItem>();
            var users = ticketService.GetAllUsers();
            foreach (var user in users)
            {
                usersSelect.Add(new SelectListItem()
                {
                    Text = user.Email,
                    Value = "" + user.Id,
                    Selected = user.Id == ticket.RecepientID ? true : false
                });
            }
            ViewBag.CategoriesList = categoriesSelect;
            ViewBag.StatusList = statusSelect;
            ViewBag.PrioritiesList = prioritiesSelect;
            ViewBag.UsersList = usersSelect;

            ticket.LastModificationDate = DateTime.Now;

            return PartialView("_Edit", ticket);
            
        }

        public ActionResult CreateTicket()
        {
            ViewBag.AuthorName = User.Identity.GetUserName();
            ViewBag.AuthorID = User.Identity.GetUserId();
            ViewBag.CategoriesList = new SelectList(ticketService.GetAllCategories(), "Id", "Name");
            ViewBag.StatusList = new SelectList(ticketService.GetAllStatus(), "Id", "Name");
            ViewBag.PrioritiesList = new SelectList(ticketService.GetAllPriorities(), "Id", "Name");
            ViewBag.UsersList = new SelectList(ticketService.GetAllUsers(), "Id", "Email");


            return PartialView("_Create");
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Ticket ticket = ticketService.GetTicketById((int)id);
                if (ticket == null)
                {
                    return HttpNotFound();
                }
                return View(ticket);
            }
        }

   

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            var nuevo = new Ticket()
            {
 
                Subject = "Prueba",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Contenido = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vehicula risus. Maecenas eu odio tempus, commodo ligula nec, mollis dolor. Donec at lacus ut ex mattis viverra. Nullam aliquam sed dolor id pulvinar. Donec vitae imperdiet risus. Aenean sed ante scelerisque, elementum odio sed, interdum metus. Praesent pulvinar lobortis lacus eget luctus. Phasellus dictum turpis tortor, quis consectetur lacus pellentesque at.",
                AuthorID = User.Identity.GetUserId(),
                RecepientID = User.Identity.GetUserId(),
                CategoryID = 1,
                PriorityID = 2,
                StatusID = 3
            };
            if (ModelState.IsValid)
            {
                ticketService.CreateNewTicket(ticket);
                return RedirectToAction("Index");
            }

            /* ViewBag.AuthorID = new SelectList(db.ApplicationUsers, "Id", "Email", ticket.AuthorID);
             ViewBag.RecepientID = new SelectList(db.ApplicationUsers, "Id", "Email", ticket.RecepientID);
             ViewBag.CategoryID = new SelectList(db.TicketCategories, "Id", "Name", ticket.CategoryID);
             ViewBag.PriorityID = new SelectList(db.TicketPriorities, "Id", "Name", ticket.PriorityID);
             ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Name", ticket.StatusID);*/
            return RedirectToAction("Index");
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = ticketService.GetTicketById((int)id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            /*ViewBag.AuthorID = new SelectList(db.ApplicationUsers, "Id", "Email", ticket.AuthorID);
            ViewBag.RecepientID = new SelectList(db.ApplicationUsers, "Id", "Email", ticket.RecepientID);
            ViewBag.CategoryID = new SelectList(db.TicketCategories, "Id", "Name", ticket.CategoryID);
            ViewBag.PriorityID = new SelectList(db.TicketPriorities, "Id", "Name", ticket.PriorityID);
            ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Name", ticket.StatusID);*/
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var OldTicket = ticketService.GetTicketById(ticket.Id);
                OldTicket.LastModificationDate = DateTime.Now;
                OldTicket.PriorityID = ticket.PriorityID;
                OldTicket.StatusID = ticket.StatusID;
                OldTicket.CategoryID = ticket.CategoryID;
                OldTicket.RecepientID = ticket.RecepientID;
                OldTicket.Subject = ticket.Subject;
                OldTicket.Contenido = ticket.Contenido;

                ticketService.EditTicket(OldTicket);
                return RedirectToAction("Index");
            }
           /* ViewBag.AuthorID = new SelectList(db.ApplicationUsers, "Id", "Email", ticket.AuthorID);
            ViewBag.RecepientID = new SelectList(db.ApplicationUsers, "Id", "Email", ticket.RecepientID);
            ViewBag.CategoryID = new SelectList(db.TicketCategories, "Id", "Name", ticket.CategoryID);
            ViewBag.PriorityID = new SelectList(db.TicketPriorities, "Id", "Name", ticket.PriorityID);
            ViewBag.StatusID = new SelectList(db.TicketStatus, "Id", "Name", ticket.StatusID);*/
            return Json(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                Ticket ticket = ticketService.GetTicketById((int)id);
                if (ticket == null)
                {
                    return HttpNotFound();
                }
            return View(ticket); }
            
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ticketService.DeleteTicket(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ticketService.Dispose(true);
            base.Dispose(disposing);
        }
    }
}
