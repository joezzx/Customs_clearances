using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;
using Newtonsoft.Json;
using Zzx.Customs_clearances.ViewModel;

namespace Zzx.Customs_clearances.Ajax.Search
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    public class Search : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            string key = context.Request.QueryString["key"];
            var model = SearchKey(key);
            context.Response.Write(JsonConvert.SerializeObject(model));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public SearchResult SearchKey(string key)
        {
            var search = new SearchResult() { Key = key };
            if (!string.IsNullOrWhiteSpace(key))
            {
                SearchKeywordManager.Search(key);        //用于统计搜索关键字的方法       
                IList<Duty_c> list = new List<Duty_c>();
                list = BLL.Search.SearchGoods(key);
                if (list.Count == 0)
                {
                    search.Error = true;
                }
                else if (list.Count == 1)
                {
                    search.Duty = list[0];
                    search.Error = false;
                    //goods_type = "<li class='one'>您输入的物品属于:  " + duty.type.overname + "--->" + duty.type.midname + "--->" + duty.type.name + "</li><br/>";
                    //name = "<li class='one'>您输入的物品相关的品名是:  " + duty.name + "</li><br/>";
                    //relatedwords = "<li class='one'>该品目相关的关键词:  " + duty.relatedwords.ToString() + "</li><br/>";
                    //price = "<li class='one'>完税价格是:  " + duty.price.ToString() + "元/" + duty.unit + "</li><br/>";
                    //rate = "<li class='one'>税率是:  " + duty.rate.ToString() + "</li><br/>";
                    //lister = goods_type + name + relatedwords + price + rate;
                }
                else if (list.Count > 1)
                {
                   
                    search.SearchTakes = list.Select(r => r.name).ToList();
                    search.Error = false;
                    search.HasResult = true;
                    //lister = "你搜索结果大于一条,请在下列项中选择: </br>";
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    lister += "<a href=default.aspx?KeyWord=" + list[i].name + ">" + list[i].name + "</a>  ";
                    //}
                }
            }
   //     string    json = JsonConvert.SerializeObject(search);
        return search;
        }
    }
}