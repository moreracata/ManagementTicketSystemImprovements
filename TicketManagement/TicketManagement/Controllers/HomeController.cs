using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement.Services;

namespace TicketManagement.Controllers
{
    public class HomeController : Controller
    {
        //private TicketService ticketService = new TicketService();

        public ActionResult Index()
        {
            //ticketService.CrearTicKetPrueba();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}