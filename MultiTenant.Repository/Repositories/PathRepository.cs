﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Common.Types;
using MultiTenant.Model;
using MultiTenant.Repository.Interfaces;

namespace MultiTenant.Repository.Repositories
{
    public class PathRepository : IPathRepository
    {
        private static PathRepository _instance = new PathRepository();
        private ICollection<ContentPath> _contentPaths; 
        private ICollection<RequestPath> _requestPaths; 
        static PathRepository() {}
        private PathRepository()
        {
            _contentPaths = new Collection<ContentPath>();
            _requestPaths = new Collection<RequestPath>();

            #region Initialize Content Paths

            _contentPaths.Add(new ContentPath
            {
                Id = TenantIds.AppleId.ToString(),
                Type = ContentTypes.RetailerPartial,
                Location = "../../Areas/Apple/Views/Retailer/General"
            });

            _contentPaths.Add(new ContentPath
            {
                Id = TenantIds.MicrosoftId.ToString(),
                Type = ContentTypes.RetailerStylesheet,
                Location = "~/Content/retailer.microsoft.bundle.css"
            });

            #endregion

            #region Initialize Request Paths

            _requestPaths.Add(new RequestPath
            {
                TenantId = TenantIds.AppleId,
                OriginalPath = "/admin/user/userview",
                NewPath = "/apple/user/userview"
            });
            _requestPaths.Add(new RequestPath
            {
                TenantId = TenantIds.AppleId,
                OriginalPath = "/report/report",
                NewPath = "/apple/report/report"
            });

            _requestPaths.Add(new RequestPath
            {
                TenantId = TenantIds.MicrosoftId,
                OriginalPath = "/report/report",
                NewPath = "/microsoft/report/report"
            });

            #endregion
        }
        public static PathRepository Instance { get { return _instance; } }

        public string GetContentLocation(string tenantId, string type)
        {
            var content = _contentPaths.FirstOrDefault(c => c.Id == tenantId && c.Type == type);
            if (content != null)
            {
                return content.Location;
            }
            return null;
        }

        public string GetRedirectPath(int tenantId, string originalPath)
        {
            var path = _requestPaths.FirstOrDefault(p => p.TenantId == tenantId && p.OriginalPath.ToLower() == originalPath.ToLower());
            if (path != null)
            {
                return path.NewPath;
            }
            return null;
        }
    }
}
