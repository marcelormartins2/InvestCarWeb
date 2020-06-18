﻿using InvestCarWeb.Data;
using InvestCarWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InvestCarWeb.Controllers
{
    public class ParceirosController : Controller
    {
        private readonly IdentyDbContext _context;
        private readonly UserManager<Parceiro> _userManager;
        private readonly SignInManager<Parceiro> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string avatarDefault = "data:image/jpeg;base64,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";

        private IHostEnvironment _env;
        
        public ParceirosController(IdentyDbContext context, 
            UserManager<Parceiro> userManager,
            SignInManager<Parceiro> signInManager,
            RoleManager<IdentityRole> roleManager,
            IHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;

        }

        // GET: Parceiros
        public async Task<IActionResult> Index()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/img/avatars", this.User.Identity.Name + ".jpg");
            if (System.IO.File.Exists(path))
            {
                ViewData["PathAvatar"] = "/img/avatars/" + User.Identity.Name + ".jpg?" + DateTime.Now.Ticks;
            }
            else
            {
                ViewData["PathAvatar"] = "/img/avatars/default2.png";
            }
            //ViewData["NomeUsuario"] = User.Identity.Name;
            var parceiro = await _context.Parceiro
                .FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
            return View(parceiro);
        }
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Parceiro.ToListAsync());
        }
        public async Task<IActionResult> Details(string id)
        {
            var email = id;
            if (email == null)
            {
                return NotFound();
            }

            var parceiro = await _context.Parceiro
                .FirstOrDefaultAsync(m => m.Email == email);
            
            if (parceiro == null)
            {
                return NotFound();
            }

            return View(parceiro);
        }

        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(String id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var parceiro = await _context.Parceiro.FindAsync(id);

            if (parceiro == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Administrator") || User.Identity.Name == parceiro.UserName)
            {
                return View(parceiro);
            }

            return Redirect(Url.Content("~/Identity/Account/AccessDenied"));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id, Parceiro parceiro)
        {
            if (id != parceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var parceiroAtual = await _context.Parceiro.FindAsync(id);
                if (parceiro.UserName != parceiroAtual.UserName)
                {
                    var pathAntigo = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/avatars", parceiroAtual.UserName + ".jpg");
                    var pathNovo = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/avatars", parceiro.UserName + ".jpg");

                    var setUserNameResult = await _userManager
                        .SetUserNameAsync(parceiroAtual, parceiro.UserName);
                    if (!setUserNameResult.Succeeded)
                    {
                        throw new InvalidOperationException(
                        $"Erro ao alterar o Nome de Usuário: '{parceiro.UserName}'.");
                    }

                    if (System.IO.File.Exists(pathAntigo))
                    {
                        System.IO.File.Move(pathAntigo, pathNovo);
                        System.IO.File.Delete(pathAntigo);
                    }
                    else if (!System.IO.File.Exists(pathNovo))
                    {
                        CriarAvatar(avatarDefault, parceiro.UserName);
                    }

                }
                if (parceiro.Email != parceiroAtual.Email)
                {
                    var setEmailResult = await _userManager
                        .SetEmailAsync(parceiroAtual, parceiro.Email);
                    if (!setEmailResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Erro ao alterar o email do usuário: '{parceiro.UserName}'.");
                    }
                }
                if (parceiro.PhoneNumber != parceiroAtual.PhoneNumber)
                {
                    var setPhoneResult = await _userManager
                        .SetPhoneNumberAsync(parceiroAtual, parceiro.PhoneNumber);
                    if (!setPhoneResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Erro ao alterar o telefone do usuário: '{parceiro.UserName}'.");
                    }
                }
                if (parceiro.LockoutEnd != parceiroAtual.LockoutEnd)
                {
                    parceiro.LockoutEnd = null;
                    var setLockoutEndResult = await _userManager
                        .SetLockoutEndDateAsync(parceiroAtual, parceiro.LockoutEnd);
                    if (!setLockoutEndResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Erro ao alterar o LockoutEnd do usuário: '{parceiro.UserName}'.");
                    }
                }
                if (parceiro.EmailConfirmed != parceiroAtual.EmailConfirmed)
                {
                    parceiroAtual.EmailConfirmed = parceiro.EmailConfirmed;
                }
                if (parceiro.Nome != parceiroAtual.Nome)
                {
                    parceiroAtual.Nome = parceiro.Nome;
                }
                if (parceiro.Endereco != parceiroAtual.Endereco)
                {
                    parceiroAtual.Endereco = parceiro.Endereco;
                }
                if (parceiro.Celular != parceiroAtual.Celular)
                {
                    parceiroAtual.Celular = parceiro.Celular;
                }

                try
                {
                    _context.Update(parceiroAtual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParceiroExists(parceiro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Lista));
            }
            return View(parceiro);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiro = await _context.Parceiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parceiro == null)
            {
                return NotFound();
            }

            return View(parceiro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var participacao = await _context.Participacao
                .FirstOrDefaultAsync(m => m.ParceiroId == id);
            var responsavel = await _context.Responsavel
                .FirstOrDefaultAsync(m => m.ParceiroId == id);
            if (participacao != null || responsavel != null)
            {
                var txtMensagem = "";
                if (participacao != null)
                {
                    if (responsavel != null)
                    {
                        txtMensagem = "Não é possível excluir o Parceiro," +
                             " pois ele tem participação em algum veículo" +
                             " e é responsável por alguma despesa.";
                    }
                    else
                    {
                        txtMensagem = "Não é possível excluir o Parceiro," +
                             " pois ele tem participação em algum veículo cadastrado.";
                    }
                } else
                {
                    txtMensagem = "Não é possível excluir o Parceiro," +
                         " pois ele é responsável por alguma despesa.";
                }
                ViewData["Mensagem"] = txtMensagem;
                return View("Error");
            }

            var parceiro = await _context.Parceiro.FindAsync(id);
            _context.Parceiro.Remove(parceiro);
            await _context.SaveChangesAsync();

            var path = Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwroot/img/avatars", parceiro.UserName + ".jpg");

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
                return RedirectToAction(nameof(Lista));
        }
        public IActionResult Avatar()
        {
            return View();
        }
        public Task<IActionResult> SaveImage(string base64image, string userName)
        {
            CriarAvatar(base64image, userName);
            return null;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Email,Celular,Endereco")] Parceiro parceiro)
        public async Task<IActionResult> Create(Parceiro parceiro)
        {

            if (ModelState.IsValid)

            {
                // parceiro = parceiro.UserId = Guid.Parse("40b72079-0bd7-4fef-97aa-add4289f23aa");
                parceiro.UserName = User.Identity.Name;
                _context.Add(parceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parceiro);
        }

        private bool CriarAvatar(string base64image, string userName)
        {
            if (base64image != null)
            {
                byte[] bytes = Convert.FromBase64String(base64image.Substring(23));
                var path = Path.Combine(
                                 Directory.GetCurrentDirectory(), "wwwroot/img/avatars", userName + ".jpg");
                using (var imageFile = new FileStream(path, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                return true;
            }
            return false;
        }
        private bool ParceiroExists(string id)
        {
            return _context.Parceiro.Any(e => e.Id == id);
        }
    }
}
