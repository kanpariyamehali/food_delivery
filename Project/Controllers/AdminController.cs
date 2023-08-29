using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Data;

namespace Project.Controllers
{
	public class AdminController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			if (TempData.Peek("user_id") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Dashboard");
			}
		}

			[HttpPost]
		public IActionResult Index(loginmodel lm)
		{
			DataSet ds = lm.login(lm.email, lm.password);
			ViewBag.login_user = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_user.Rows)
            {
				TempData["user_id"] = dr["id"].ToString();
            }

			if (TempData.Peek("user_id") != null)
			{
				return RedirectToAction("Dashboard");
			}
			else
			{
				return Redirect("Index");
			}
        }

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(loginmodel lm)
		{
			int data = lm.register(lm.name, lm.email, lm.password, lm.conatct, lm.gender);

			if (data != 0)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Register");
			}
		}
		public IActionResult Dashboard()
		{
			return View();
		}
	}
}
