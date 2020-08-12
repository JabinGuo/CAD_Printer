using System;
namespace DB.Model
{
    /// <summary>
    /// TASK:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TASK
    {
        public TASK()
        { }
        #region Model
        private string _task_guid;
        private string _file_fullname;
        private decimal? _ordered = null;
        private DateTime? _printing_time = Convert.ToDateTime(null);
        private string _save_path;
        private string _printer;
        private string _paper;
        private decimal? _isprinting;
        /// <summary>
        /// 
        /// </summary>
        public string TASK_GUID
        {
            set { _task_guid = value; }
            get { return _task_guid; }
        }
        /// <summary>
        /// dwg文件完整路径
        /// </summary>
        public string FILE_FULLNAME
        {
            set { _file_fullname = value; }
            get { return _file_fullname; }
        }
        /// <summary>
        /// 被哪个CAD进程预约
        /// </summary>
        public decimal? ORDERED
        {
            set { _ordered = value; }
            get { return _ordered; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PRINTING_TIME
        {
            set { _printing_time = value; }
            get { return _printing_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SAVE_PATH
        {
            set { _save_path = value; }
            get { return _save_path; }
        }
        /// <summary>
        /// 指定打印机
        /// </summary>
        public string PRINTER
        {
            set { _printer = value; }
            get { return _printer; }
        }
        /// <summary>
        /// 指定纸张尺寸
        /// </summary>
        public string PAPER
        {
            set { _paper = value; }
            get { return _paper; }
        }
        /// <summary>
        /// 被哪个进程打印
        /// </summary>
        public decimal? ISPRINTING
        {
            set { _isprinting = value; }
            get { return _isprinting; }
        }
        #endregion Model

    }
}

