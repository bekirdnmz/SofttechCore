using Filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Filters
{
    public class StopwatchAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();


        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            // TODO 1: sonucu, Model ile birlikte gönder.
            /*
             * 
             * 
             * 
             * 1. Model
             * 2. View
             * 3. Doğrudan Response.WriteAsync()
             * 
             */

            //2. View:


            //3. Doğrudan Response.WriteAsync():
            //var result = context.Result as ContentResult;
            //if (result != null)
            //{
            //    result.Content += $"<br/>Stopwatch: {_stopwatch.Elapsed.TotalSeconds}";
            //}

            //1. Model:
            var viewResult = context.Result as ViewResult;
            var model = (ModelBase)viewResult.Model;
            if (model == null)
            {
               
                if (viewResult != null)
                {
                    viewResult.ViewData["Stopwatch"] = $"{_stopwatch.ElapsedMilliseconds}";
                }
            }
            else
            {
                model.TotalSeconds = _stopwatch.Elapsed.TotalSeconds;
            }



            _stopwatch.Restart();
        }


    }
}
