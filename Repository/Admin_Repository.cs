using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Admin_Repository : RepositoryBase<tbl_admin>, IAdmin_Repository
    {
        public Admin_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public dynamic GetAdmin()
        {
            var result = (from admin in RepositoryContext.tbl_admin

                          select admin
                        ).ToList();
            return result;
        }

        public dynamic GetAdminbyid(int id)
        {
            var result = (from admin in RepositoryContext.tbl_admin
                          where admin.admin_id == id
                          select admin
                        ).FirstOrDefault();
            return result;
        }

        public dynamic GetAdminRolebyid(int id)
        {
            var result = (from admin in RepositoryContext.tbl_admin
                          join Role in RepositoryContext.tbl_role_admin on admin.admin_id equals Role.admin_id
                          where admin.admin_id == id
                          select admin
                        ).FirstOrDefault();
            return result;
        }
        public IEnumerable<dynamic> GetAdminLoginValidation(string username)
        {
            return (from usr in RepositoryContext.tbl_admin
                    join ul in RepositoryContext.tbl_role on usr.admin_role_id equals ul.role_id into tmp
                    from c in tmp
                    where usr.admin_login_name == (string)username
                    select new
                    {
                        Password = usr.admin_password,
                        Salt = usr.admin_salt,
                        AdminID = usr.admin_id,
                        AdminName = usr.admin_name,
                        AdminLevelID = usr.admin_role_id,
                        login_fail_count = usr.admin_login_fail_count,
                        access_status = usr.admin_access_status,
                        Email = usr.admin_email,
                        ImagePath = usr.admin_photo_path,
                        LoginName = usr.admin_login_name,
                        CompanyID = 1,
                        restricted_iplist = ""
                    });
        }

        public Admin FindById(int ID)
        {
            var item = (from adm in RepositoryContext.tbl_admin
                        where adm.admin_id == ID
                        select adm
                        ).FirstOrDefault();
            tbl_admin usr = item as tbl_admin;
            Admin admin = new Admin();
            admin.Password = usr.admin_password;
            admin.Salt = usr.admin_salt;
            admin.AdminID = usr.admin_id;
            admin.AdminName = usr.admin_name;
            admin.AdminLevelID = usr.admin_role_id;
            admin.login_fail_count = usr.admin_login_fail_count;
            admin.access_status = Convert.ToSByte(usr.admin_access_status);
            admin.Email = usr.admin_email;
            admin.ImagePath = usr.admin_photo_path;
            admin.LoginName = usr.admin_login_name;
            admin.CompanyID = "1";
            return admin;
        }

    }
}