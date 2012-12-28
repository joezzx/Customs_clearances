<%@ Page Title="任我游-致力于为旅客通关服务" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zzx.Customs_clearances._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
       
             <div class="searchcenter navbar-search pull-left form form-search" style="padding-top: 10px;">  
             <input type="text" class="search-query input-xlarge"  placeholder="任我游-致力于为旅客通关服务" ID="TextBox1" runat="server" />
              
                  <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="搜索" OnClick="Button1_Click" />
               </div> <br/><br /><br />  
            <%=Tag %>         
                      
            <br />   <br />
           <div class="one">
            <ul class="round">
         
               <%=lister %>
            </ul>
    </div>
                    
            
               
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h4>个人行李物品通关小贴士:</h4>
    <ol class="round">
        <li class="one">
            <h5>注意携带行李物品的数量</h5>
            个人行李物品在规定数量范围内可以免征税，对于超过规定数量但仍然属于自用合理范围内按照物品征税，对于超过规定数量过大已经不属于自用合理范围内的物品（即时不是用于交易目的）仍将按照货物征税，按货物的税率将高于按物品的税率.<a href="">Learn more…</a></li>
        <li class="two">
            <h5>注意携带行李物品的属性</h5>
            行李物品总的来说分为三类，禁止进出境物品，限制进出境物品，允许进出境物品，对于携带禁止进出境物品的旅客，若数量过大，将涉嫌走私，海关将会予以依法处理物品携带者并依法没收该货物.<a href="">Learn more…</a></li>
        <li class="three">
            <h5>注意进出境海关的公告</h5>
            对于物品的征税的政策经常会有小的变动，根据进出境当地海关的公告，可以让您更加便捷的通关.<a href="">Learn more…</a></li>
          <li class="four">
            <h5>注意进出境海关的公告</h5>
            对于物品的征税的政策经常会有小的变动，根据进出境当地海关的公告，可以让您更加便捷的通关.<a href="">Learn more…</a></li>

          </ol>
</asp:Content>
