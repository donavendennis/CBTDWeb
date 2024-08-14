using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
	public class DeleteModel : PageModel
	{
		private readonly UnitOfWork _unitOfWork;
		[BindProperty]
		public Manufacturer? objManufacturer { get; set; }
		public DeleteModel(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult OnGet(int? id)
		{
			objManufacturer = new Manufacturer();
			//am I in edit mode?
			if (id != 0)
			{
				objManufacturer = _unitOfWork.Manufacturer.GetById(id);
			}
			if (objManufacturer == null)
			{
				return NotFound();
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_unitOfWork.Manufacturer.Delete(objManufacturer);
			TempData["success"] = "Manufacturer Deleted Successfully";
			_unitOfWork.Commit();
			return RedirectToPage("./Index");
		}
	}
}
