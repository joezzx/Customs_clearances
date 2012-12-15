using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;


namespace DAL
{
    public class Search
    {
        #region
        /// <summary>
        /// 搜索物品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IList<Duty_c> SearchGoods(string keyword)
        {
            string safeSql = "select *  from Duty_c";
            if (keyword.Trim().Length > 0)
            {
                safeSql += " where name like '%" + keyword + "%'";
            }
            return GetPartialGoodsBySql(safeSql);
        }

        /// <summary>
        /// 返回不完整字段的物品
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        private static IList<Duty_c> GetPartialGoodsBySql(string safeSql)
        {
            List<Duty_c> list = new List<Duty_c>();
            DataTable table = DBHelper.GetDataSet(safeSql);
            foreach (DataRow row in table.Rows)
            {
                Duty_c duty_c = new Duty_c();
                duty_c.duty_id = (string)row["duty_id"];
                duty_c.name = (string)row["name"];
                duty_c.price = (int)row["price"];
                duty_c.unit=(string)row["unit"];
                duty_c.rate=(double)row["rate"];
             
                duty_c.type=(int)row["type"]; //FK
                list.Add(duty_c);
            }
            return list;
        }
        #endregion
    }
}
