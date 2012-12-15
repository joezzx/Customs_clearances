using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Models;

namespace BLL
{
    public class Search
    {
        /// <summary>
        /// 搜索物品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IList<Duty_c> SearchGoods(string keyword)
        {
            return DAL.Search.SearchGoods(keyword);
        }
    }
}
