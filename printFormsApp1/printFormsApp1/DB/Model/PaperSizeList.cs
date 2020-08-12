using System;
namespace DB.Model
{
    /// <summary>
    /// PAPER_SIZE:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PAPER_SIZE
    {
        public PAPER_SIZE()
        { }
        #region Model
        private string _guid;
        private string _paper_name;
        private decimal? _paper_length;
        private decimal? _paper_width;
        private decimal? _paper_pixel_length;
        private decimal? _paper_pixel_width;
        /// <summary>
        /// 
        /// </summary>
        public string GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PAPER_NAME
        {
            set { _paper_name = value; }
            get { return _paper_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PAPER_LENGTH
        {
            set { _paper_length = value; }
            get { return _paper_length; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PAPER_WIDTH
        {
            set { _paper_width = value; }
            get { return _paper_width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PAPER_PIXEL_LENGTH
        {
            set { _paper_pixel_length = value; }
            get { return _paper_pixel_length; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PAPER_PIXEL_WIDTH
        {
            set { _paper_pixel_width = value; }
            get { return _paper_pixel_width; }
        }
        #endregion Model

    }
}

