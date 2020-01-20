
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using System;

namespace Ethereal_EM
{
    public static class KendoDataSourceRequestUtil
    {
        public static DataSourceRequest Parse(dynamic param)
        {
            dynamic objParamInfo = param.gridState;
            string page = objParamInfo.page;
            string pageSize = objParamInfo.pageSize;
            string sort = objParamInfo.sort;
            string group = objParamInfo.group;
            string filter = objParamInfo.filter;
            string aggregates = objParamInfo.aggregate;

            DataSourceRequest request = new DataSourceRequest();

            try
            {

                if (!string.IsNullOrEmpty(page))
                {
                    int p = 0;
                    Int32.TryParse(page, out p);
                    request.Page = p;
                }

                if (!string.IsNullOrEmpty(pageSize))
                {
                    int psize = 0;
                    Int32.TryParse(pageSize, out psize);
                    request.PageSize = psize;
                }

                if (!string.IsNullOrEmpty(sort))
                {
                    request.Sorts = DataSourceDescriptorSerializer.Deserialize<SortDescriptor>(sort);
                }

                if (!string.IsNullOrEmpty(filter))
                {
                    request.Filters = FilterDescriptorFactory.Create(filter);
                }

                if (!string.IsNullOrEmpty(group))
                {
                    request.Groups = DataSourceDescriptorSerializer.Deserialize<GroupDescriptor>(group);
                }

                if (!string.IsNullOrEmpty(aggregates))
                {
                    request.Aggregates = DataSourceDescriptorSerializer.Deserialize<AggregateDescriptor>(group);
                }
            }
            catch (Exception ex)
            {
                var msg=ex.Message;
            }
            return request;
        }
    }
}
