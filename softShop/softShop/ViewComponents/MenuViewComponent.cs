using Microsoft.AspNetCore.Mvc;

namespace softShop.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var list = new List<string> { "Anasayfa", "Hakkımda", "İletişim" };
            return View(list);
        }
    }
}
