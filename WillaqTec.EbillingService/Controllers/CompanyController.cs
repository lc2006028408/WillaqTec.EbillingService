using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillaqTec.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? id, int? courseID)
        {

            var companyEntities = await _companyService.GetAllAsync();


            return View(companyEntities);
        }

        // GET: Instructors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View(new Models.Company());
        }

        // POST: Instructors/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentityDocumentNumber,BusinessName,Address")] CompanyEntity companyEntity)
        {
            companyEntity.UserId = HttpContext.Session.GetInt32("userId").Value;
            companyEntity.CreatorUser = "";
            companyEntity.UpdaterUser = "";
            companyEntity.CreateDate = DateTime.Now;
            companyEntity.UpdateDate = DateTime.Now;
            companyEntity.Status = true;
            companyEntity.Removed = false;
            await _companyService.AddAsync(companyEntity);
            return RedirectToAction("Index", "Company");
        }

        // GET: Instructors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _companyService.GetByIdAsync(id.Value);

            return View(companyEntity);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CompanyId,IdentityDocumentNumber,BusinessName,Address")] CompanyEntity companyEntity)
        {
            if (companyEntity.CompanyId == 0)
            {
                return NotFound();
            }

            companyEntity.UserId = 1;
            companyEntity.CreatorUser = "";
            companyEntity.UpdaterUser = "";
            companyEntity.CreateDate = DateTime.Now;
            companyEntity.UpdateDate = DateTime.Now;
            companyEntity.Status = true;
            companyEntity.Removed = false;

            await _companyService.UpdateAsync(companyEntity);

            return RedirectToAction("Index", "Company");
        }

        // GET: Instructors/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyEntity = await _companyService.GetByIdAsync(id.Value);
            if (companyEntity == null)
            {
                return NotFound();
            }

            return View(companyEntity);
        }

        // POST: Instructors/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyEntity = await _companyService.GetByIdAsync(id);
            
            companyEntity.Status = false;
            companyEntity.Removed = true;
            await _companyService.UpdateAsync(companyEntity);
            return RedirectToAction(nameof(Index));
        }

    }
}
