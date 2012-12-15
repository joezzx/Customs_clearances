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
using BLL;
using Models;

namespace Zzx.Customs_clearances
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
      //保留的方法      IList<Duty_c> ilist = new List<Duty_c>();
      //                ilist=Search.SearchGoods(TextBox1.Text);

            Databind();
        }

        private void Databind()
        {
            PagedDataSource pdsGoods = new PagedDataSource();
            //对PagedDataSource 对象的相关属性赋值        
            pdsGoods.DataSource = BLL.Search.SearchGoods(TextBox1.Text);
            pdsGoods.AllowPaging = true;
           

            //把PagedDataSource 对象赋给DataList控件 
            rpGoodList.DataSource = pdsGoods;
            rpGoodList.DataBind();
        }

    }


  
}