using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace Zzx.Customs_clearances.UserControl
{
    public partial class SearchTag : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.litTag.Text = CreateTag();
        }


        //生成热门标签
        public string CreateTag()
        {
            var tag = "";
            IList<SearchKeyword> Tags = new List<SearchKeyword>();
            Tags = BLL.SearchKeywordManager.GetHottag();
            if (Tags != null && Tags.Count >= 1)
            {
                tag = "热门标签：   ";
                for (int i = 0; i < Tags.Count; i++)
                {
                    tag += "<a href=default.aspx?KeyWord=" + Tags[i].keyword + ">" + Tags[i].keyword + "</a>  ";
                }
            }
            return tag;

        }
    }
}