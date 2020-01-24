using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Menu_Repository : RepositoryBase<tbl_menu>, IMenu_Repository
    {
        public Menu_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public List<tbl_menu> GetMenu()
        {
            var result1 = (from menu in RepositoryContext.tbl_menu
                           select menu
                        ).ToList();
            List<tbl_menu> result = result1 as List<tbl_menu>;
            return result;
        }
    }
}