using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dnx.Working.Controllers
{
    public class HomeController : Controller
    {
	    public async Task<IActionResult> Index()
	    {
		    return View();
	    }
    }
}