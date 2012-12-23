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
    public class SearchKeywordManager
    {

        //搜索计数
        public static void Search(string keyword)
        {
            SearchKeyword skw = SearchKeywords.GetKeyword(keyword);
            if (skw == null)
            {
                skw = new SearchKeyword();
                skw.keyword = keyword;
                skw.searchCount = 1;
                SearchKeywords.AddSearchKeyword(skw);
            }
            else
            {
                skw.searchCount++;
                SearchKeywords.ModifySearchKeyword(skw);
            }
        }


        //获取热门标签的方法
        public static IList<SearchKeyword> GetHottag()
        {
            return SearchKeywords.GetHottag();
        }

    }
}
