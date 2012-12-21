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

            public string lister = string.Empty;  //返回界面值;

        public string nocontext = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["KeyWord"] != null && Request.QueryString["KeyWord"].ToString().Trim() != "")
            {
                Listbind(Request.QueryString["KeyWord"]);
            }
            else
            {
                ViewState["KeyWord"] = "";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text=="")
            {
                //ajax方法？
            }
            else
            {
            Listbind(TextBox1.Text);

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
            lister = "";
            IList<Duty_c> list = new List<Duty_c>();
            list = BLL.Search.SearchGoods(text);
            if (list.Count<1)
            {
                lister = "Sorry~ 您搜索的内容没有找到，您可以选择<a href='AdvancdSearch.aspx'>高级搜索</a>";
            }
            if (list.Count == 1)
            {
                Duty_c duty = list[0];
                name = "  <li class='one'>您输入的物品相关的项目是:" + duty.name + "</li>";
                price = "<li class='one'>完税价格是;" + duty.price.ToString() + "元/" + duty.unit + "</li>";
                rate = "<li class='one'>税率是;" + duty.rate.ToString() +"</li>";
                lister = name + price + rate;
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
    }


  
}