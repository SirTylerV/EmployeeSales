using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services.Helpers
{
    public static class PaginationService
    {
        /*
         * This fucntion will give populate the min and max numbers for a pagination that will have 7 options
         * maxPages - The max number of pages the padigator can go to
         * currentPage - The page the user is currently on
         * start - The first number you will see in the pagination. This value is set in the function
         * end - The last number you will see in the pagination. This value is set in the function
         */
        public static void SetStartAndEndPagination(int maxPages, int currentPage, out int start, out int end)
        {
            var min = 1;
            if(maxPages <= 7)
            {
                start = min;
                end = maxPages;
                return;
            }
            start = (currentPage - 3) <= min ? min : currentPage - 3;
            end = (currentPage + 3) >= maxPages ? maxPages : (currentPage + 3);
            if (start == min && end != 7)
            {
                end = 7;
            }
            else if (end == maxPages && start != (maxPages - 6))
            {
                start = (maxPages - 6);
            }
        }

        /*
         * The function to Pagination any IEnumerable and return the list of the current page
         * list - The list of items to padignate
         * 
         */
        public static List<T> PaginateList<T>(IEnumerable<T> list, int pageNumber, int pageSize)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
