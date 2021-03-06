﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using InvestCarWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InvestCarWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvestCarWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<Parceiro> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IdentyDbContext _context;

        public LoginModel(SignInManager<Parceiro> signInManager,
            ILogger<LoginModel> logger,
            IdentyDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            //[EmailAddress]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Parceiro logado.");
                    var parceiro = await _context.Parceiro
                        .FirstOrDefaultAsync(m => m.UserName == Input.UserName);
                    if (parceiro.Nome == null)
                    {
                        return LocalRedirect(Url.Content("/Parceiros/Edit/"+parceiro.Id));
                    }
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Conta bloqueada.");
                    //return RedirectToPage("./Lockout");

                    ModelState.AddModelError(string.Empty, "Conta bloqueada. Tente mais tarde.");
                    return Page();
                }
                else
                {
                    var parceiro = await _context.Parceiro
                        .FirstOrDefaultAsync(m => m.UserName == Input.UserName);
                    if (parceiro == null)
                    {
                        ModelState.AddModelError(string.Empty, "Usuário não cadastrado.");
                    }else if (parceiro.EmailConfirmed)
                    {
                        ModelState.AddModelError(string.Empty, "Senha não confere.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Conta aguardando liberação.");
                    }
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
