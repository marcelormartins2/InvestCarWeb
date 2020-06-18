using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestCarWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InvestCarWeb.Areas.Identity.Pages.Account
{
    public class RegistroConfirmado : PageModel
    {
        private readonly SignInManager<Parceiro> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        public RegistroConfirmado(SignInManager<Parceiro> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            _signInManager.SignOutAsync();
            _logger.LogInformation("Usuário deslogado com sucesso!");
            return Page();
        }
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Usuário deslogado com sucesso!");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }

}
