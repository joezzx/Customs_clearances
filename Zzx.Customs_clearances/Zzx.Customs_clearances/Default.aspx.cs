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
       string name = string.Empty;
       string price= string.Empty;
       string rate = string.Empty;
       string relatedwords = string.Empty;
       string goods_type = string.Empty;

         public string lister = string.Empty;  //返回界面值;
         public string Tag = string.Empty; //热门标签

        public string nocontext = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //根据是否初次加载判定文本框的赋值
            if (!IsPostBack)
            {
                CreatTag();
                if (Request.QueryString["KeyWord"] != null && Request.QueryString["KeyWord"].ToString().Trim() != "")
                {
                    TextBox1.Value = Request.QueryString["KeyWord"];
                    Listbind(Request.QueryString["KeyWord"]);   //该处是否请求一个新的页面有待考虑
                }
                else
                {
                    ViewState["KeyWord"] = "";
                }
            }
            else
            {
                CreatTag();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Value.Trim()=="")
            {
                //ajax方法？
            }
            else
            {
                Listbind(TextBox1.Value);  //根据输入结果生成前台数据

            }
        }

        private void Databind()
        {
       /*     PagedDataSource pdsGoods = new PagedDataSource();
            //对PagedDataSource 对象的相关属性赋值        
            pdsGoods.DataSource = BLL.Search.SearchGoods(TextBox1.Text);
            pdsGoods.AllowPaging = true;
            if (pdsGoods.Count > 1)
            {
                //把PagedDataSource 对象赋给DataList控件 
               rpGoodList.DataSource = pdsGoods;
               rpGoodList.DataBind();
            }     
            */
       
        }

        //通过列表的方法实现不同的返回结果
        private void Listbind(string text)
        {
            SearchKeywordManager.Search(TextBox1.Value);        //用于统计搜索关键字的方法       
            lister = "";
            IList<Duty_c> list = new List<Duty_c>();
            list = BLL.Search.SearchGoods(text);
            if (list.Count<1)
            {
                lister = "Sorry~ 您搜索的  <font color='red'>" + text + "</font>  没有找到，您可以选择<a href='AdvancedSearch.aspx'>高级搜索</a>";
            }
            if (list.Count == 1)
            {
                Duty_c duty = list[0];
                goods_type="<li class='one'>您输入的物品属于:  " + duty.type.overname + "--->" +duty.type.midname + "--->" + duty.type.name + "</li><br/>";
                name = "<li class='one'>您输入的物品相关的品名是:  " + duty.name + "</li><br/>";
                relatedwords = "<li class='one'>该品目相关的关键词:  " + duty.relatedwords.ToString() + "</li><br/>";
                price = "<li class='one'>完税价格是:  " + duty.price.ToString() + "元/" + duty.unit + "</li><br/>";
                rate = "<li class='one'>税率是:  " + duty.rate.ToString() + "</li><br/>";
                lister = goods_type + name + relatedwords + price + rate;
            }
            if (list.Count > 1)
            {
                lister = "你搜索结果大于一条,请在下列项中选择: </br>";
                for (int i = 0; i < list.Count; i++)
                {
                    lister += "<a href=default.aspx?KeyWord=" + list[i].name + ">" + list[i].name + "</a>  ";
                }
            }
        }

        //生成热门标签
        private void CreatTag()
        {
            Tag = "";
            IList<SearchKeyword> Tags = new List<SearchKeyword>();
            Tags = BLL.SearchKeywordManager.GetHottag();
            if (Tags.Count>=1)
            {
                Tag = "热门标签：   ";
                for (int i = 0; i < Tags.Count; i++)
                {
                    Tag += "<a href=default.aspx?KeyWord=" + Tags[i].keyword + ">" + Tags[i].keyword + "</a>  ";
                }
            }
     

        }
    }


  
}