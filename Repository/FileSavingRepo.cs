using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class FileSavingRepo : RepositoryBase<FileSaveModel>, IFileSavingRepo
    {
        public FileSavingRepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}