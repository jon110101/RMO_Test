using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMO
{
    /// <summary>
    /// UsrManageModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]

    public class UsrManageModel
    {
        public UsrManageModel()
        { }
        #region Model
        private string _company_id;
        private string _role_id;
        private string _pgm_id;
        private string _name;
        private string _pgm_up;
        private string _query_rights_id;
        private string _export_rights_id;
        private string _insert_rights_id;
        private string _update_rights_id;
        private string _delete_rights_id;
        private string _print_rights_id;
        private int _Itm;
        /// <summary>
        /// 
        /// </summary>
        public string Company_Id
        {
            set { _company_id = value; }
            get { return _company_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Role_Id
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pgm_Id
        {
            set { _pgm_id = value; }
            get { return _pgm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pgm_Up
        {
            set { _pgm_up = value; }
            get { return _pgm_up; }
        }
    
        /// <summary>
        /// 
        /// </summary>
        public string Query_Rights_Id
        {
            set { _query_rights_id = value; }
            get { return _query_rights_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Export_Rights_Id
        {
            set { _export_rights_id = value; }
            get { return _export_rights_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Insert_Rights_Id
        {
            set { _insert_rights_id = value; }
            get { return _insert_rights_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Update_Rights_Id
        {
            set { _update_rights_id = value; }
            get { return _update_rights_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Delete_Rights_Id
        {
            set { _delete_rights_id = value; }
            get { return _delete_rights_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Print_Rights_Id
        {
            set { _print_rights_id = value; }
            get { return _print_rights_id; }
        }
     
              /// <summary>
        /// 
        /// </summary>
        public int Itm
        {
            set { _Itm = value; }
            get { return _Itm; }
        }
        
        #endregion Model

    }
}

