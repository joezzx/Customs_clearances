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
                safeSql += "or relatedwords like '%" + keyword + " %'";
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
                int typeid;
                Duty_c duty_c = new Duty_c();
                duty_c.duty_id = (string)row["duty_id"];
                duty_c.name = (string)row["name"];
                duty_c.price = (int)row["price"];
                duty_c.unit=(string)row["unit"];
                duty_c.rate=(double)row["rate"];
                if (row["relatedwords"] !=DBNull.Value)
                { 
                    duty_c.relatedwords = (string)row["relatedwords"]; 
                }
                else
                {
                    duty_c.relatedwords = "无";
                }//相关词库列表
                typeid = (int)row["type"];
                duty_c.limits=(int)row["limits"];  //外键
                duty_c.grade = (int)row["grade"];  //外键
                duty_c.type=GoodsType.GetGoodsTypeById(typeid); //外键
                list.Add(duty_c);           
            }
            return list;
        }
        #endregion
    }
}
