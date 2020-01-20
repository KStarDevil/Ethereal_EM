using Ethereal_EM;
using Ethereal_EM.Repository;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDb RepositoryContext { get; set; }
        public string _OldObjString { get; set; }

        public RepositoryBase(AppDb repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public T FindByID(int ID)
        {

            T obj;

            obj = this.RepositoryContext.Set<T>().Find(ID);

            return obj;
        }
         public T FindByString(string ID)
        {

            T obj;

            obj = this.RepositoryContext.Set<T>().Find(ID);

            return obj;
        }
        
        
        public T FindByCompositeID(int ID1, int ID2)
        {
            T obj;
            obj = this.RepositoryContext.Set<T>().Find(ID1, ID2);

            return obj;
        }
        public bool AnyByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Any(expression);
        }
        public T FindByCompositeID(int ID1, int ID2, int ID3)
        {
            T obj;
            obj = this.RepositoryContext.Set<T>().Find(ID1, ID2, ID3);

            return obj;
        }
        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(dynamic entity, bool flush = true)
        {
            entity.SetEventLogMessage(this.SetOldObjectToString(entity));
            this.RepositoryContext.Set<T>().Add(entity);
            if (flush) this.Save();
        }

        public void Update(dynamic entity, bool flush = true)
        {
            entity.SetEventLogMessage(this.GetUpdateEventLogString(entity));
            this.RepositoryContext.Set<T>().Update(entity);
            if (flush) this.Save();
        }

        public void Delete(dynamic entity, bool flush = true)
        {
            entity.SetEventLogMessage(this.SetOldObjectToString(entity));
            this.RepositoryContext.Set<T>().Remove(entity);
            if (flush) this.Save();
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }

        public string SetOldObjectToString(dynamic OldObj)
        {
            _OldObjString = "";
            JObject _duplicateObj = JObject.FromObject(OldObj);
            var _List = _duplicateObj.ToObject<Dictionary<string, object>>();
            foreach (var item in _List)
            {
                var name = item.Key;
                var val = item.Value;
                string msg = name + " : " + val + "\r\n";
                _OldObjString += msg;
            }
            return _OldObjString;
        }

        public string GetOldObjectString()
        {
            return this._OldObjString;
        }
        
        public String GetUpdateEventLogString(dynamic entity)
        {
            PropertyValues  oldObj;
            string _OldObjString = "";
            try
            {
                oldObj = this.RepositoryContext.Entry(entity).OriginalValues;
                if (oldObj == null) return "";
                JObject _newObj = JObject.FromObject(entity);
                var _newList = _newObj.ToObject<Dictionary<string, object>>();

                foreach (var item in oldObj.Properties)
                {
                    var name = item.Name;
                    var val = oldObj[name] != null ? oldObj[name].ToString().Trim() : "";
                    var newval = _newList.GetValueOrDefault(name) != null ? _newList.GetValueOrDefault(name).ToString().Trim() : "";
                    string msg = "";
                    if(val != newval) msg = name + " : " + val + " >>> " + newval + "\r\n";
                    _OldObjString += msg;
                }
            }
            catch (Exception ex)
            {
                Globalfunction.WriteSystemLog("Exception :" + ex.Message);
            }
            return _OldObjString;
        }

        public dynamic GetPermission(int id)
        {
            throw new NotImplementedException();
        }
    }
}
