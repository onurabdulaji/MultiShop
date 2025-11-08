using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewCompnents
{
    public class _ShoppingCartDiscountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
