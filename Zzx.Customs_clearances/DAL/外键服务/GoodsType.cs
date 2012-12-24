using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;


namespace DAL
{
    public class GoodsType
    {
        public static Goods_Type GetGoodsTypeById(int id)
        {
            string sql = "SELECT * FROM Goods_type WHERE type = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Goods_Type goods_Type = new Goods_Type();

                    goods_Type.type = (int)reader["type"];
                    goods_Type.name = (string)reader["name"];
                    goods_Type.midname = (string)reader["midname"];
                    goods_Type.overname = (string)reader["overname"];


                    reader.Close();

                    return goods_Type;
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

    }
}
