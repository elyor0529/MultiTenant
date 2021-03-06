﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Controllers;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Areas.Apple.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ITenantService tenantService) : base(tenantService)
        {
        }
        //
        // GET: /Apple/AppleUser/

        public ActionResult UserView()
        {
            BaseViewModel model = new BaseViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Index", model);
        }

    }
}
