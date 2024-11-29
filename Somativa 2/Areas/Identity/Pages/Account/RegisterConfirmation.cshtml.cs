// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Somativa_2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterConfirmationModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        ///     Este campo armazena o e-mail do usuário registrado.
        /// </summary>
        public string Email { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com o e-mail '{email}'.");
            }

            Email = email;

            // Confirma automaticamente o e-mail do usuário
            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true; // Define a propriedade como confirmada
                await _userManager.UpdateAsync(user); // Atualiza o usuário no banco de dados
            }

            // Redireciona para a página de login ou qualquer outra página
            return RedirectToPage("/Account/Login");
        }
    }
}