﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Models;

namespace MultiTenant.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.Host = Host;
            return View("Index", model);
        }

    }
}