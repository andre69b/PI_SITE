using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using Factory;
using LogicLibrary;
using LogicModelLibrary;

namespace PI.Controllers
{
    public class DestinationController : AbstractController
    {
        private Calendar _calendar;
        public DestinationController()
        {
            this._calendar = new Calendar();
        }

        //
        // GET: /Destination/
        public ActionResult Index(int id=-1) 
        {
            var v = rl.GeTById(id);
            if (id == -1)
            {
                return RedirectToAction("Page");
            }
            if (v == null)
                return RedirectToRoute("notFound");


            Calendar.OneDay[][] arr = _calendar.GetArrayCalendar(v);


            return View("OneDestination", new RealEstateWithCalendar(v, arr,arr));

        }
        public ActionResult ChangeMonth(RealEstateWithCalendar.ChangeMonth ch, int id)
        {
            int year = ch.GetYear();
            int month = ch.GetMonth();
            if (ch.Move.Equals("next"))
            {
                if (month == 12)
                {
                    month = 1;
                    ++year;
                }
                else ++month;
            }
            else
            {
                if (month == 1)
                {
                    month = 12;
                    --year;
                }
                else --month;
            }
            var v = rl.GeTById(id);
            Calendar.OneDay[][] arr = _calendar.GetArrayCalendar(v,year, month);
            var c = new RealEstateWithCalendar.CalendarCheck(arr, ch.Type);
            return PartialView("Calendar",c);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Appreciation(RealEstate.Appreciation ap, int id=0)
        {
            ap.DayOfAppreciation = DateTime.Now;
            ap.Author = User.Identity.Name;
            rl.GeTById(id)._Appreciations.AddAppreciation(ap);
            return PartialView("PartialViewAppreciation", ap);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Check(RealEstateWithCalendar.Check check, int id)
        {
            DateTime In = check.GetDateTimeCheckIn();
            DateTime Out = check.GetDateTimeCheckOut();

            RealEstate r = rl.GeTById(id);

            if (r._AvailabilityOfTheProperty.AddReservation(In, Out,User.Identity.Name))
            {

                return View("CheckSuccessful");
            }
            return View("CheckFailed");
        }
        public ActionResult Page(int id = 1, int ajax = 0)
        {
            if (ajax == 1) return PageAjax(id);
            id--;
            if (id < 0)
                return RedirectToRoute("notFound");
            Info info = new Info(rl.GetAll(), id , Info.DEFAULT);
            return View("Index", info);
        }
        public ActionResult PageAjax(int id = 1)
        {
            id--;

            Info info = new Info(rl.GetAll(), id, Info.DEFAULT);

            return PartialView("PartialView", info);
        }      
    }
}
