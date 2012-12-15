<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zzx.Customs_clearances._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <p>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="搜一搜" OnClick="Button1_Click" />
            </p>
            <p>
                 <asp:DataList ID="rpGoodList" runat="server">
            <ItemTemplate>
            <ul class="round">
                <li class="one" >您输入的物品相关的项目是：<%# Eval("name") %></li>  
                <li class="one"> 完税价格是;<%#Eval("price")%>元/<%#Eval("unit")%></li> 
                           <li class="one"> 税率是;<%#Eval("rate")%></li>    
            </ul>
            </ItemTemplate>  
             
            </asp:DataList>    
                </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
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
