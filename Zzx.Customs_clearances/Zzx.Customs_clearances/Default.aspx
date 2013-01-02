<%@ Page Title="任我游-致力于为旅客通关服务" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zzx.Customs_clearances._Default" %>

<%@ Register Src="UserControl/SearchTag.ascx" TagName="SearchTag" TagPrefix="Search" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   <script src="Scripts/knockout-2.2.0.js"></script>
     <section class="featured">
        <div class="content-wrapper">

            <div class="searchcenter navbar-search pull-left form form-search" style="padding-top: 10px; padding-bottom: 10px;">
                <input class="search-query input-xlarge" id="txtSearch" type="text" placeholder="任我游-致力于为旅客通关服务" />
                <button class="btn btn-success" id="btnSearch">搜索</button>
            </div>
            <Search:SearchTag ID="SearchTag1" runat="server" />
            <div class="one">
            

       <h4>Goods</h4>
              <ul  data-bind="foreach: SearchNames">   
                 <li>      
                    Goods at position <span data-bind="text: $index"> </span>:
                        <b data-bind="text: $data"></b>

                          <a href="#" data-bind="click: $parent.removeGoods">Remove</a>
                                                  </li>               
              </ul>          
                <button data-bind="click: addGoods">Add</button>
            </div>
        </div>
    </section>
    
      
          
               
    <script type="text/javascript">
        
       
        $(document).ready(function () {
            $("#btnSearch").click(function () {
                var key = document.getElementById('txtSearch').value;
                $.ajax({
                    url: "Ajax/Search/Search.ashx?key=" + key,
                    success: function (data) {
                        var json = JSON.parse(data);
                        if (json.SearchTakes == null) {
                            var ReturnModels = {
                                Name: ko.observable(json.Duty.name),  
                                Rate: ko.observable(json.Duty.rate)
                            };
                            ko.applyBindings(ReturnModels);
                                            }
                        else {
                            function AppViewModel() {
                                var self = this;
                                self.SearchNames = ko.observableArray(json.SearchTakes);
                                self.addGoods = function ()
                                { self.SearchNames.push({ $data: "New at " + new Date() }); };

                                self.removeGoods = function ()
                                { self.SearchNames.remove(this); };

                            }
                            ko.applyBindings(new AppViewModel());
                          
                       //     ko.applyBindings({ SearchNames: ko.observableArray(Duty.SearchTakes) });
                            //js 的循环呐！         
                        }
                    },
                    error: function () {
                        alert("您要找的东西不存在!");
                    }

                });
            });
        });
        
    </script>






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
