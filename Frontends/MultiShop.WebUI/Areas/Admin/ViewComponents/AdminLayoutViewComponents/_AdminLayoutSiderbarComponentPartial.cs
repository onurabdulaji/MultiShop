using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSiderbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
