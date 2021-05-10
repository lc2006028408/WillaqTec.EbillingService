using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WillaqTec.Controllers
{
    public class SingUpController : Controller
    { 
        private readonly IPersonService _personService;
        private readonly IUserService _userService;
        
        public SingUpController(IPersonService personService, IUserService userService)
        {
            _personService = personService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> SingUp(int IdentityDocumentTypeId, string IdentityDocumentTypeNumber,string FatherLastName,string MotherLastName,string Name,string Email, string Password)
        {
            PersonEntity personEntity = new PersonEntity();
            UserEntity userEntity = new UserEntity();

            personEntity.PersonId = 0;
            personEntity.IdentityDocumentTypeId = IdentityDocumentTypeId;
            personEntity.IdentityDocumentNumber = IdentityDocumentTypeNumber;
            personEntity.FatherLastName = FatherLastName;
            personEntity.MotherLastName = MotherLastName;
            personEntity.Name = Name;
            personEntity.Email = Email;
            personEntity.CreatorUser = "";
            personEntity.UpdaterUser = "";
            personEntity.CreateDate = DateTime.Now;
            personEntity.UpdateDate = DateTime.Now;
            personEntity.Status = true;
            personEntity.Removed = false;

            var indicadorPerson = await _personService.AddAsync(personEntity);

            userEntity.UserId = 0;
            userEntity.PersonId = personEntity.PersonId;
            userEntity.UserName = personEntity.IdentityDocumentNumber;
            userEntity.Password = UtilitarianUTL.EncriptarCadena(Password);
            userEntity.CreatorUser = "";
            userEntity.UpdaterUser = "";
            userEntity.CreateDate = DateTime.Now;
            userEntity.UpdateDate = DateTime.Now;
            userEntity.Status = true;
            userEntity.Removed = false;

            var indicadorUser = await _userService.AddAsync(userEntity);

            if (indicadorUser== 1)
            {
                return RedirectToAction("Index", "Login");
            }


            return View();
        }
    }
}
