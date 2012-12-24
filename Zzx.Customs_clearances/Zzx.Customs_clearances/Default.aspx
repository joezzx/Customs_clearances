<%@ Page Title="任我游-致力于为旅客通关服务" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zzx.Customs_clearances._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <p>
                <input  placeholder="任我游-致力于为旅客通关服务" ID="TextBox1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
           <%=Tag %> </p>
           <div class="one">
            <ul class="round">
         
               <%=lister %>
            </ul>
    </div>
                    
            
               
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>个人行李物品通关小贴士:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.<a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a></li>
        <li class="two">
            <h5>Add NuGet packages and jump start your coding</h5>
            NuGet makes it easy to install and update free libraries and tools.<a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a></li>
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.<a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a></li>
    </ol>
</asp:Content>
