using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool AnyByCondition(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public dynamic GetPosition(int Id)
        {
            var query = (from User in RepositoryContext.Users
                                        
                        join position in RepositoryContext.position_model on User.id equals position.ID
                        where User.id == Id
                         select new
                         {
                            
                            Name= User.name,
                            Position= position.Position,
                            Phone= User.phone,
                            Address= User.address,
                            Email= User.email

                         });
            return query; 



            
        }

        public dynamic GetUser(int Id)
        {    
            var query = (from User in RepositoryContext.Users

                        join position in RepositoryContext.position_model on User.id equals position.ID
                        join company1 in RepositoryContext.Company1 on User.id equals company1.id
                        join Department in RepositoryContext.Department on User.id equals Department.D_ID
                        where User.id == Id
                         select new
                         {
                            
                            Name= User.name,
                            Position= position.Position,
                            Phone= User.phone,
                            Address= User.address,
                            Email= User.email,
                            C_Name =company1.C_Name,
                            C_Phone =company1.C_Phone,
                            C_Address=company1.C_Address,
                            C_Description=company1.C_Description,
                            D_Name=Department.D_Name,
                            D_ID=Department.D_ID,
                            D_Location=Department.D_Location,
                            D_Description=Department.D_Description

                         }).ToList();
            return query;
        }

        IEnumerable<User> IRepositoryBase<User>.FindAll()
        {
            throw new NotImplementedException();
        }

        User IRepositoryBase<User>.FindByCompositeID(int ID1, int ID2)
        {
            throw new NotImplementedException();
        }

        User IRepositoryBase<User>.FindByCompositeID(int ID1, int ID2, int ID3)
        {
            throw new NotImplementedException();
        }

        User IRepositoryBase<User>.FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        User IRepositoryBase<User>.FindByString(string ID)
        {
            throw new NotImplementedException();
        }

      
    }
}