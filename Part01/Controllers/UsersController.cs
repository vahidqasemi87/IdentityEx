using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Part01.Models.AAA;
using System.Threading.Tasks;

namespace Part01.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        public UsersController(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = _userManager.Users;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new UserAppViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserAppViewModel inputViewModel)
        {
            if (!ModelState.IsValid)
                return View(inputViewModel);
            var user = new UserApp
            {
                UserName = inputViewModel.Username,
                Email = inputViewModel.Email
            };
            var resultCreate = await _userManager.CreateAsync(user, inputViewModel.Password);
            if (resultCreate.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (var error in resultCreate.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(inputViewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id));
            if (!user.Succeeded)
            {
                foreach (var error in user.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return RedirectToAction("Index");
        }
    }
}