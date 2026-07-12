using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Reflection;
using TransitOps.Attributes;

namespace TransitOps.Filters
{
    public class GlobalSearchFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string searchString = context.HttpContext.Request.Query["searchString"];

            if (context.Result is ViewResult viewResult)
            {
                if (context.Controller is Controller controller)
                {
                    controller.ViewBag.CurrentSearchString = searchString;
                }

                if (!string.IsNullOrWhiteSpace(searchString) && viewResult.Model is IEnumerable enumerableModel)
                {
                    var modelType = viewResult.Model.GetType();
                    Type itemType = modelType.GetInterfaces()
                        .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                        .Select(t => t.GetGenericArguments()[0])
                        .FirstOrDefault();

                    if (itemType != null)
                    {
                        var searchableProps = itemType.GetProperties()
                            .Where(p => p.GetCustomAttribute<SearchableAttribute>() != null)
                            .ToList();

                        if (searchableProps.Any())
                        {
                            var filteredItems = enumerableModel.Cast<object>().Where(item =>
                            {
                                foreach (var prop in searchableProps)
                                {
                                    var val = prop.GetValue(item);
                                    if (val != null && val.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                                    {
                                        return true; 
                                    }
                                }
                                return false; 
                            }).ToList();

                            var listType = typeof(List<>).MakeGenericType(itemType);
                            var typedList = (IList)Activator.CreateInstance(listType);

                            foreach (var item in filteredItems)
                            {
                                typedList.Add(item);
                            }

                            viewResult.ViewData.Model = typedList;
                        }
                    }
                }
            }
        }
    }
}