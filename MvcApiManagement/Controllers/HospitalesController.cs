﻿using Microsoft.AspNetCore.Mvc;
using MvcApiManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiManagement.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceApiHospital service;

        public HospitalesController(ServiceApiHospital service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.service.GetHospitalesAsync());
        }
    }
}
