using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BLL;
using Models;

namespace Zzx.Customs_clearances
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        //通过列表的方法实现不同的返回结果
        //private void Listbind(string text)
        //{
            //SearchKeywordManager.Search(TextBox1.Value);        //用于统计搜索关键字的方法       
            //lister = "";
            //IList<Duty_c> list = new List<Duty_c>();
            //list = BLL.Search.SearchGoods(text);
            //if (list.Count < 1)
            //{
            //    lister = "Sorry~ 您搜索的  <font color='red'>" + text + "</font>  没有找到，您可以选择<a href='AdvancedSearch.aspx'>高级搜索</a>";
            //}
            //if (list.Count == 1)
            //{
            //    Duty_c duty = list[0];
            //    goods_type = "<li class='one'>您输入的物品属于:  " + duty.type.overname + "--->" + duty.type.midname + "--->" + duty.type.name + "</li><br/>";
            //    name = "<li class='one'>您输入的物品相关的品名是:  " + duty.name + "</li><br/>";
            //    relatedwords = "<li class='one'>该品目相关的关键词:  " + duty.relatedwords.ToString() + "</li><br/>";
            //    price = "<li class='one'>完税价格是:  " + duty.price.ToString() + "元/" + duty.unit + "</li><br/>";
            //    rate = "<li class='one'>税率是:  " + duty.rate.ToString() + "</li><br/>";
            //    lister = goods_type + name + relatedwords + price + rate;
            //}
            //if (list.Count > 1)
            //{
            //    lister = "你搜索结果大于一条,请在下列项中选择: </br>";
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        lister += "<a href=default.aspx?KeyWord=" + list[i].name + ">" + list[i].name + "</a>  ";
            //    }
            //}
        //}
    }



}