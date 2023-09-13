using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtobusAPI.Entities;

namespace APIOtobusUI.Areas.SysAdmin.Controllers
{
    [Area("SysAdmin")]
    public class SysAdminController : Controller
    {
        private static HttpClient _httpClient;
        public SysAdminController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7172/");
        }

        // GET: SysAdminController
        public async Task<ActionResult> Index()
        {
            var getTask = await _httpClient.GetAsync("api/AppUser");
            if (getTask.IsSuccessStatusCode)
            {
                var readTask = getTask.Content.ReadAsAsync<List<AppUser>>();
                return View(readTask.Result);
            }
            return View();
        }








        // GET: SysAdminController/Details/5
        public async Task<ActionResult>  Details(int id)
        {
            var getTask = await _httpClient.GetAsync("api/AppUser/" + id.ToString());
            if (getTask.IsSuccessStatusCode)
            {
                var readTask=await getTask.Content.ReadAsAsync<AppUser>();
                return View(readTask);
            }
            return View();
        }








        // GET: SysAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppUser appUser)
        {
            var postTask = await _httpClient.PostAsJsonAsync<AppUser>("api/AppUser", appUser);
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View(appUser);
            }
        }








        // GET: SysAdminController/Edit/5
        public async Task<ActionResult>  Edit(int id)
        {
            var getTask = await _httpClient.GetAsync("api/AppUser");
            var readTask=await getTask.Content.ReadAsAsync<List<AppUser>>();
            AppUser appUser = readTask.FirstOrDefault(x => x.Id == id);
            return View(appUser);
        }

        // POST: SysAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AppUser appUser)
        {
            var postTask = await _httpClient.PutAsJsonAsync<AppUser>("api/AppUser", appUser);
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error=postTask.Content;
                return View(appUser);
            }
        }






        // GET: SysAdminController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getTask = await _httpClient.GetAsync("api/AppUser");
            var readTask = await getTask.Content.ReadAsAsync<List<AppUser>>();
            AppUser appUser = readTask.FirstOrDefault(x => x.Id == id);
            return View(appUser);
        }

        // POST: SysAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Delete(int id, AppUser appUser)
        {
            var postTask = await _httpClient.DeleteAsync("api/AppUser/" + id.ToString());
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View();
            }
        }
    }
}
