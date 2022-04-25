using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Filters.Filters
{
    public class NotImplementedAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Eğer hata oluşursa, başka bir View'a yönlendir.
            if (context.Exception is NotImplementedException)
            {
                string message = $"{context.ActionDescriptor.DisplayName} isimli action henüz tamamlanmamış";
                context.Result = new ViewResult()
                {
                    ViewName = "NotImplemented",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = message
                    }
                };
            }

            base.OnException(context);
        }
    }
}
