﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageController.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageController.Pages.Components.EmployeeCount
{
    public class EmployeeCountViewComponent : ViewComponent
    {
        private readonly EmployeeDbContext _context;
        public EmployeeCountViewComponent(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _context.Employees.CountAsync();
            return View(new EmployeeCountViewModel(count));
        }
    }
}
