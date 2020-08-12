using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Maticsoft.DBUtility;//Please add references
namespace DB.DAL
{
    /// <summary>
    /// 数据访问类:PAPER_SIZE
    /// </summary>
    public partial class PAPER_SIZE
    {
        public PAPER_SIZE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PAPER_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PAPER_SIZE");
            strSql.Append(" where PAPER_NAME=:PAPER_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":PAPER_NAME", OracleType.VarChar,100)          };
            parameters[0].Value = PAPER_NAME;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DB.Model.PAPER_SIZE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PAPER_SIZE(");
            strSql.Append("GUID,PAPER_NAME,PAPER_LENGTH,PAPER_WIDTH,PAPER_PIXEL_LENGTH,PAPER_PIXEL_WIDTH)");
            strSql.Append(" values (");
            strSql.Append(":GUID,:PAPER_NAME,:PAPER_LENGTH,:PAPER_WIDTH,:PAPER_PIXEL_LENGTH,:PAPER_PIXEL_WIDTH)");
            OracleParameter[] parameters = {
                    new OracleParameter(":GUID", OracleType.VarChar,100),
                    new OracleParameter(":PAPER_NAME", OracleType.VarChar,100),
                    new OracleParameter(":PAPER_LENGTH", OracleType.Number,8),
                    new OracleParameter(":PAPER_WIDTH", OracleType.Number,8),
                    new OracleParameter(":PAPER_PIXEL_LENGTH", OracleType.Number,5),
                    new OracleParameter(":PAPER_PIXEL_WIDTH", OracleType.Number,5)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.PAPER_NAME;
            parameters[2].Value = model.PAPER_LENGTH;
            parameters[3].Value = model.PAPER_WIDTH;
            parameters[4].Value = model.PAPER_PIXEL_LENGTH;
            parameters[5].Value = model.PAPER_PIXEL_WIDTH;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DB.Model.PAPER_SIZE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PAPER_SIZE set ");
            strSql.Append("GUID=:GUID,");
            strSql.Append("PAPER_LENGTH=:PAPER_LENGTH,");
            strSql.Append("PAPER_WIDTH=:PAPER_WIDTH,");
            strSql.Append("PAPER_PIXEL_LENGTH=:PAPER_PIXEL_LENGTH,");
            strSql.Append("PAPER_PIXEL_WIDTH=:PAPER_PIXEL_WIDTH");
            strSql.Append(" where PAPER_NAME=:PAPER_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":GUID", OracleType.VarChar,100),
                    new OracleParameter(":PAPER_LENGTH", OracleType.Number,8),
                    new OracleParameter(":PAPER_WIDTH", OracleType.Number,8),
                    new OracleParameter(":PAPER_PIXEL_LENGTH", OracleType.Number,5),
                    new OracleParameter(":PAPER_PIXEL_WIDTH", OracleType.Number,5),
                    new OracleParameter(":PAPER_NAME", OracleType.VarChar,100)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.PAPER_LENGTH;
            parameters[2].Value = model.PAPER_WIDTH;
            parameters[3].Value = model.PAPER_PIXEL_LENGTH;
            parameters[4].Value = model.PAPER_PIXEL_WIDTH;
            parameters[5].Value = model.PAPER_NAME;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PAPER_NAME)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PAPER_SIZE ");
            strSql.Append(" where PAPER_NAME=:PAPER_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":PAPER_NAME", OracleType.VarChar,100)          };
            parameters[0].Value = PAPER_NAME;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PAPER_NAMElist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PAPER_SIZE ");
            strSql.Append(" where PAPER_NAME in (" + PAPER_NAMElist + ")  ");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB.Model.PAPER_SIZE GetModel(string PAPER_NAME)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GUID,PAPER_NAME,PAPER_LENGTH,PAPER_WIDTH,PAPER_PIXEL_LENGTH,PAPER_PIXEL_WIDTH from PAPER_SIZE ");
            strSql.Append(" where PAPER_NAME=:PAPER_NAME ");
            OracleParameter[] parameters = {
                    new OracleParameter(":PAPER_NAME", OracleType.VarChar,100)          };
            parameters[0].Value = PAPER_NAME;

            DB.Model.PAPER_SIZE model = new DB.Model.PAPER_SIZE();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB.Model.PAPER_SIZE DataRowToModel(DataRow row)
        {
            DB.Model.PAPER_SIZE model = new DB.Model.PAPER_SIZE();
            if (row != null)
            {
                if (row["GUID"] != null)
                {
                    model.GUID = row["GUID"].ToString();
                }
                if (row["PAPER_NAME"] != null)
                {
                    model.PAPER_NAME = row["PAPER_NAME"].ToString();
                }
                if (row["PAPER_LENGTH"] != null && row["PAPER_LENGTH"].ToString() != "")
                {
                    model.PAPER_LENGTH = decimal.Parse(row["PAPER_LENGTH"].ToString());
                }
                if (row["PAPER_WIDTH"] != null && row["PAPER_WIDTH"].ToString() != "")
                {
                    model.PAPER_WIDTH = decimal.Parse(row["PAPER_WIDTH"].ToString());
                }
                if (row["PAPER_PIXEL_LENGTH"] != null && row["PAPER_PIXEL_LENGTH"].ToString() != "")
                {
                    model.PAPER_PIXEL_LENGTH = decimal.Parse(row["PAPER_PIXEL_LENGTH"].ToString());
                }
                if (row["PAPER_PIXEL_WIDTH"] != null && row["PAPER_PIXEL_WIDTH"].ToString() != "")
                {
                    model.PAPER_PIXEL_WIDTH = decimal.Parse(row["PAPER_PIXEL_WIDTH"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GUID,PAPER_NAME,PAPER_LENGTH,PAPER_WIDTH,PAPER_PIXEL_LENGTH,PAPER_PIXEL_WIDTH ");
            strSql.Append(" FROM PAPER_SIZE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PAPER_SIZE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PAPER_NAME desc");
            }
            strSql.Append(")AS Row, T.*  from PAPER_SIZE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleType.VarChar, 255),
					new OracleParameter(":fldName", OracleType.VarChar, 255),
					new OracleParameter(":PageSize", OracleType.Number),
					new OracleParameter(":PageIndex", OracleType.Number),
					new OracleParameter(":IsReCount", OracleType.Clob),
					new OracleParameter(":OrderType", OracleType.Clob),
					new OracleParameter(":strWhere", OracleType.VarChar,1000),
					};
			parameters[0].Value = "PAPER_SIZE";
			parameters[1].Value = "PAPER_NAME";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

