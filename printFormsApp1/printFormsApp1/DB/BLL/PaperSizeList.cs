using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using DB.Model;
namespace DB.BLL
{
    /// <summary>
    /// PAPER_SIZE
    /// </summary>
    public partial class PAPER_SIZE
    {
        private readonly DB.DAL.PAPER_SIZE dal = new DB.DAL.PAPER_SIZE();
        public PAPER_SIZE()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PAPER_NAME)
        {
            return dal.Exists(PAPER_NAME);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DB.Model.PAPER_SIZE model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DB.Model.PAPER_SIZE model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PAPER_NAME)
        {

            return dal.Delete(PAPER_NAME);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PAPER_NAMElist)
        {
            return dal.DeleteList(PAPER_NAMElist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB.Model.PAPER_SIZE GetModel(string PAPER_NAME)
        {

            return dal.GetModel(PAPER_NAME);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public DB.Model.PAPER_SIZE GetModelByCache(string PAPER_NAME)
        {

            string CacheKey = "PAPER_SIZEModel-" + PAPER_NAME;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PAPER_NAME);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DB.Model.PAPER_SIZE)objModel;
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
        public List<DB.Model.PAPER_SIZE> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB.Model.PAPER_SIZE> DataTableToList(DataTable dt)
        {
            List<DB.Model.PAPER_SIZE> modelList = new List<DB.Model.PAPER_SIZE>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DB.Model.PAPER_SIZE model;
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

