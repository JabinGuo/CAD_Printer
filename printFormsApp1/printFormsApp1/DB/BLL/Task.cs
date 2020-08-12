using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using DB.Model;
namespace DB.BLL
{
    /// <summary>
    /// TASK
    /// </summary>
    public partial class TASK
    {
        private readonly DB.DAL.TASK dal = new DB.DAL.TASK();
        public TASK()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TASK_GUID)
        {
            return dal.Exists(TASK_GUID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DB.Model.TASK model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DB.Model.TASK model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string TASK_GUID)
        {

            return dal.Delete(TASK_GUID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TASK_GUIDlist)
        {
            return dal.DeleteList(TASK_GUIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB.Model.TASK GetModel(string TASK_GUID)
        {

            return dal.GetModel(TASK_GUID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public DB.Model.TASK GetModelByCache(string TASK_GUID)
        {

            string CacheKey = "TASKModel-" + TASK_GUID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(TASK_GUID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DB.Model.TASK)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB.Model.TASK> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB.Model.TASK> DataTableToList(DataTable dt)
        {
            List<DB.Model.TASK> modelList = new List<DB.Model.TASK>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DB.Model.TASK model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

