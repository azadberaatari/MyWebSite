﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
//using BusinessLayer.ValidationRules_Fluent_Validation;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using BussinesLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        
        //[AllowAnonymous]
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult ContactSideBarPartial()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetMessageSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetMessagesInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = messageManager.GetMessageSendBox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = messageManager.GetMessagesInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = messageManager.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }
}