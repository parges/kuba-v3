using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace kubaapi.utils
{
    public class QueryOptions
    {
        public QueryOptions()
        {
            PageIndex = 1;
            PageSize = int.MaxValue;
            SortColumn = "Id";
            SortDirection = ListSortDirection.Ascending;
        }

        public QueryOptions(int pageIndex = 1, int pageSize = int.MaxValue, string sortColumn = "Id", ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            PageIndex = pageIndex > 0 ? pageIndex : 1;
            PageSize = pageSize;
            SortColumn = sortColumn;
            SortDirection = sortDirection;
        }

        /// <summary>
        /// PageIndex (1 based!!)
        /// </summary>
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}
