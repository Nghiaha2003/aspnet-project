﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace League.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    private readonly LeagueContext _context;

        public IndexModel(ILogger<IndexModel> logger, LeagueContext context)
    {
      _logger = logger;
      _context = context;
    }

        public void OnGet()
    {

    }
  }
}
