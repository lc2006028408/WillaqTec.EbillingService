using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WillaqTec.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPersonService _personService;

        public UserController(IUserService userService,IPersonService personService)
        {
            _userService = userService;
            _personService = personService;

        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var personUser = new Models.PersonUser();
            var userId = HttpContext.Session.GetInt32("userId").Value;

            var userEntity = await _userService.GetByIdAsync(userId);
            var personEntity = await _personService.GetByIdAsync(userEntity.PersonId);
            personUser.user = userEntity;
            personUser.person = personEntity;

            return View(personUser);
        }

        [Authorize]
        public async Task<IActionResult> Save()
        {
            var personUser = new Models.PersonUser();
            var userId = HttpContext.Session.GetInt32("userId").Value;

            var userEntity = await _userService.GetByIdAsync(userId);
            var personEntity = await _personService.GetByIdAsync(userEntity.PersonId);
            personUser.user = userEntity;
            personUser.person = personEntity;

            return View(personUser);
        }
    }
}
