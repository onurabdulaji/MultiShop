namespace MultiShop.Basket.LoginServices
{
    public class LoginService(IHttpContextAccessor _httpContextAccessor) : ILoginService
    {
        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
