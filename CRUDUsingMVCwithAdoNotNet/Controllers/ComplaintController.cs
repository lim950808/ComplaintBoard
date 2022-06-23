using CRUDUsingMVCwithAdoNotNet.Models;
using CRUDUsingMVCwithAdoNotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoNotNet.Controllers
{
    public class ComplaintController : Controller
    {
        // GET: Complaint
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddComplaint(ComplaintModel ObjComp)
        {
            try
            {
                ComplaintRepo Obj = new ComplaintRepo();
                //Getting complaintId and assigning   
                //to ViewBag with custom message to show user  
                ViewBag.ComplaintId = "Complaint raised successfully, Your complaintId is " + Obj.AddComplaint(ObjComp);
            }
            catch (Exception)
            {
                //Assigning custom message to ViewBag to show users, If any error occures.  
                ViewBag.ComplaintId = "Error while raising complaint, Please check details";
            }
            return View();
        }
    }
}