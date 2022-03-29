using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLast.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Extensions
{
    public static class ConvertExtensions
    {
        public static List<SelectListItem> ConvertToSelectList<T>(this IEnumerable<T> collection, int selectedValue) where T:IPrimaryProperties
        {
            return (from item in collection
                    select new SelectListItem
                    { 
                      Text = item.Name,
                      Value = item.Code.ToString(),
                      Selected = (item.Code == selectedValue)
                    }



                  ).ToList(); 
        }
            }
}
