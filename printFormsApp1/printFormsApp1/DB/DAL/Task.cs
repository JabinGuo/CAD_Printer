using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Maticsoft.DBUtility;//Please add references
namespace DB.DAL
{
    /// <summary>
    /// 数据访问类:TASK
    /// </summary>
    public partial class TASK
    {
        public TASK()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TASK_GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TASK");
            strSql.Append(" where TASK_GUID=:TASK_GUID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TASK_GUID", OracleType.VarChar,100)           };
            parameters[0].Value = TASK_GUID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DB.Model.TASK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TASK(");
            strSql.Append("TASK_GUID,FILE_FULLNAME,ORDERED,PRINTING_TIME,SAVE_PATH,PRINTER,PAPER,ISPRINTING)");
            strSql.Append(" values (");
            strSql.Append(":TASK_GUID,:FILE_FULLNAME,:ORDERED,:PRINTING_TIME,:SAVE_PATH,:PRINTER,:PAPER,:ISPRINTING)");
            OracleParameter[] parameters = {
                    new OracleParameter(":TASK_GUID", OracleType.VarChar,100),
                    new OracleParameter(":FILE_FULLNAME", OracleType.VarChar,500),
                    new OracleParameter(":ORDERED", OracleType.Number,1),
                    new OracleParameter(":PRINTING_TIME", OracleType.DateTime),
                    new OracleParameter(":SAVE_PATH", OracleType.VarChar,500),
                    new OracleParameter(":PRINTER", OracleType.VarChar,50),
                    new OracleParameter(":PAPER", OracleType.VarChar,50),
                    new OracleParameter(":ISPRINTING", OracleType.Number,1)};
            parameters[0].Value = model.TASK_GUID;
            parameters[1].Value = model.FILE_FULLNAME;
            parameters[2].Value = model.ORDERED;
            parameters[3].Value = model.PRINTING_TIME;
            parameters[4].Value = model.SAVE_PATH;
            parameters[5].Value = model.PRINTER;
            parameters[6].Value = model.PAPER;
            parameters[7].Value = model.ISPRINTING;

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
        public bool Update(DB.Model.TASK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TASK set ");
            strSql.Append("FILE_FULLNAME=:FILE_FULLNAME,");
            strSql.Append("ORDERED=:ORDERED,");
            strSql.Append("PRINTING_TIME=:PRINTING_TIME,");
            strSql.Append("SAVE_PATH=:SAVE_PATH,");
            strSql.Append("PRINTER=:PRINTER,");
            strSql.Append("PAPER=:PAPER,");
            strSql.Append("ISPRINTING=:ISPRINTING");
            strSql.Append(" where TASK_GUID=:TASK_GUID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":FILE_FULLNAME", OracleType.VarChar,500),
                    new OracleParameter(":ORDERED", OracleType.Number,1),
                    new OracleParameter(":PRINTING_TIME", OracleType.DateTime),
                    new OracleParameter(":SAVE_PATH", OracleType.VarChar,500),
                    new OracleParameter(":PRINTER", OracleType.VarChar,50),
                    new OracleParameter(":PAPER", OracleType.VarChar,50),
                    new OracleParameter(":ISPRINTING", OracleType.Number,1),
                    new OracleParameter(":TASK_GUID", OracleType.VarChar,100)};
            parameters[0].Value = model.FILE_FULLNAME;
            parameters[1].Value = model.ORDERED;
            parameters[2].Value = model.PRINTING_TIME;
            parameters[3].Value = model.SAVE_PATH;
            parameters[4].Value = model.PRINTER;
            parameters[5].Value = model.PAPER;
            parameters[6].Value = model.ISPRINTING;
            parameters[7].Value = model.TASK_GUID;

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
        public bool Delete(string TASK_GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TASK ");
            strSql.Append(" where TASK_GUID=:TASK_GUID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TASK_GUID", OracleType.VarChar,100)           };
            parameters[0].Value = TASK_GUID;

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
        public bool DeleteList(string TASK_GUIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TASK ");
            strSql.Append(" where TASK_GUID in (" + TASK_GUIDlist + ")  ");
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
        public DB.Model.TASK GetModel(string TASK_GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TASK_GUID,FILE_FULLNAME,ORDERED,PRINTING_TIME,SAVE_PATH,PRINTER,PAPER,ISPRINTING from TASK ");
            strSql.Append(" where TASK_GUID=:TASK_GUID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":TASK_GUID", OracleType.VarChar,100)           };
            parameters[0].Value = TASK_GUID;

            DB.Model.TASK model = new DB.Model.TASK();
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
        public DB.Model.TASK DataRowToModel(DataRow row)
        {
            DB.Model.TASK model = new DB.Model.TASK();
            if (row != null)
            {
                if (row["TASK_GUID"] != null)
                {
                    model.TASK_GUID = row["TASK_GUID"].ToString();
                }
                if (row["FILE_FULLNAME"] != null)
                {
                    model.FILE_FULLNAME = row["FILE_FULLNAME"].ToString();
                }
                if (row["ORDERED"] != null && row["ORDERED"].ToString() != "")
                {
                    model.ORDERED = decimal.Parse(row["ORDERED"].ToString());
                }
                if (row["PRINTING_TIME"] != null && row["PRINTING_TIME"].ToString() != "")
                {
                    model.PRINTING_TIME = DateTime.Parse(row["PRINTING_TIME"].ToString());
                }
                if (row["SAVE_PATH"] != null)
                {
                    model.SAVE_PATH = row["SAVE_PATH"].ToString();
                }
                if (row["PRINTER"] != null)
                {
                    model.PRINTER = row["PRINTER"].ToString();
                }
                if (row["PAPER"] != null)
                {
                    model.PAPER = row["PAPER"].ToString();
                }
                if (row["ISPRINTING"] != null && row["ISPRINTING"].ToString() != "")
                {
                    model.ISPRINTING = decimal.Parse(row["ISPRINTING"].ToString());
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
            strSql.Append("select TASK_GUID,FILE_FULLNAME,ORDERED,PRINTING_TIME,SAVE_PATH,PRINTER,PAPER,ISPRINTING ");
            strSql.Append(" FROM TASK ");
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
            strSql.Append("select count(1) FROM TASK ");
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
                strSql.Append("order by T.TASK_GUID desc");
            }
            strSql.Append(")AS Row, T.*  from TASK T ");
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
			parameters[0].Value = "TASK";
			parameters[1].Value = "TASK_GUID";
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

