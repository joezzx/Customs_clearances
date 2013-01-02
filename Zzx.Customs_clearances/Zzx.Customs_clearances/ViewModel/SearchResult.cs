using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Zzx.Customs_clearances.ViewModel
{
    /// <summary>
    /// 查询返回类
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// 查询是否有结果
        /// </summary>
        public bool HasResult { get; set; }

        /// <summary>
        /// 查询是否有错误 （未找到结果）
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 查询得到的结果数量
        /// </summary>
        public int ElementCount { get; set; }

        /// <summary>
        /// 唯一查询后得到的结果
        /// </summary>
        public Duty_c Duty { get; set; }

        /// <summary>
        /// 存在多个查询结果时，给予用户返回的二次查询关键字
        /// </summary>
        public List<string> SearchTakes { get ; set; }
    }
}