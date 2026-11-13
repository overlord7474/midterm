using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midtermproject.Data;
using midtermproject.ViewModels;

namespace midtermproject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // 1. AUTHORIZATION (LOGIN) ACTIONS
        // ==========================================

        [HttpGet]
        public IActionResult Login()
        {
            var sessionEmail = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(sessionEmail))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower() && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Authorization failed: Invalid email or password.");
                return View(model);
            }

            HttpContext.Session.SetString("Email", user.Email);
            return RedirectToAction("Index");
        }

        // ==========================================
        // 2. ACCOUNT INFORMATION PAGE ACTIONS
        // ==========================================

        [HttpGet]
        public async Task<IActionResult> Index(string Email)
        {
            // Fallback to session if Email parameter is missing
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // Optional: Logout action
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
