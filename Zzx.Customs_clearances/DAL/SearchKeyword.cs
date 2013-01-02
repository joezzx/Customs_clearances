using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class SearchKeywords
    {
        // 根据关键字内容获得关键字对象
        public static SearchKeyword GetKeyword(string keyword)
        {
            string sql = "SELECT * FROM SearchKeywords WHERE keyword = @keyword";

            using (SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@keyword", keyword)))
            {
                if (reader.Read())
                {
                    SearchKeyword searchKeyword = new SearchKeyword();
                    searchKeyword.id = (int)reader["Id"];
                    searchKeyword.keyword = (string)reader["Keyword"];
                    searchKeyword.searchCount = (int)reader["SearchCount"];
                    reader.Close();
                    return searchKeyword;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        //添加关键字对象
        public static SearchKeyword AddSearchKeyword(SearchKeyword searchKeyword)
        {
            string sql =
                "INSERT SearchKeywords (Keyword, SearchCount)" +
                "VALUES (@Keyword, @SearchCount)";

            sql += " ; SELECT @@IDENTITY";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Keyword", searchKeyword.keyword),
					new SqlParameter("@SearchCount", searchKeyword.searchCount)
				};

                int newId = DBHelper.GetScalar(sql, para);
                return GetSearchKeywordById(newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //返回单个关键字段
        public static SearchKeyword GetSearchKeywordById(int id)
        {
            string sql = "SELECT * FROM SearchKeywords WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    SearchKeyword searchKeyword = new SearchKeyword();

                    searchKeyword.id = (int)reader["Id"];
                    searchKeyword.keyword = (string)reader["Keyword"];
                    searchKeyword.searchCount = (int)reader["SearchCount"];

                    reader.Close();

                    return searchKeyword;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //修改数据库相关字段
        public static void ModifySearchKeyword(SearchKeyword searchKeyword)
        {
            string sql =
                "UPDATE SearchKeywords " +
                "SET " +
                    "Keyword = @Keyword, " +
                    "SearchCount = @SearchCount " +
                "WHERE Id = @Id";


            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", searchKeyword.id),
					new SqlParameter("@Keyword", searchKeyword.keyword),
					new SqlParameter("@SearchCount", searchKeyword.searchCount)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

        //获取热门标签的方法
        public static IList<SearchKeyword> GetHottag()
        {
            string sql = "select top 5 * from Searchkeywords order by SearchCount DESC";
            return GetSearchKeywordsBySql(sql);
        }

        //返回具体关键字的查询
        private static IList<SearchKeyword> GetSearchKeywordsBySql(string safeSql)
        {
            List<SearchKeyword> list = new List<SearchKeyword>();
            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);
                foreach (DataRow row in table.Rows)
                {
                    SearchKeyword searchKeyword = new SearchKeyword();

                    searchKeyword.id = (int)row["Id"];
                    searchKeyword.keyword = (string)row["Keyword"];
                    searchKeyword.searchCount = (int)row["SearchCount"];
                    list.Add(searchKeyword);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        private static IList<SearchKeyword> GetSearchKeywordsBySql(string sql, params SqlParameter[] values)
        {
            List<SearchKeyword> list = new List<SearchKeyword>();
            try
            {
                DataTable table = DBHelper.GetDataSet(sql, values);
                foreach (DataRow row in table.Rows)
                {
                    SearchKeyword searchKeyword = new SearchKeyword();

                    searchKeyword.id = (int)row["Id"];
                    searchKeyword.keyword = (string)row["Keyword"];
                    searchKeyword.searchCount = (int)row["SearchCount"];
                    list.Add(searchKeyword);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

    }
}
