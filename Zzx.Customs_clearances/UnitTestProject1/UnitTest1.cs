using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Zzx.Customs_clearances.ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void CreateJsonString()
        {
            var search = new SearchResult();
            search.ElementCount = 10;
            search.Duty = new Models.Duty_c()
            {
                duty_id = "1",
                grade = 2,
                limits = 3,
                name = "苹果",
                price = 100,
                rate = 0.01,
                relatedwords = "apple",
                type = new Models.Goods_Type() { midname = "midnameGoods_Type", name = "nameGoods_Type", overname = "overnameGoods_Type", type = 99 },
                unit = "unit"
            };
            search.Error = false;
            search.HasResult = true;
            search.Key = "苹果";
            search.SearchTakes = new System.Collections.Generic.List<string>() { 
             "苹果","梨子","香蕉"
            };
            string json = JsonConvert.SerializeObject(search);
            Console.WriteLine(json);
            //{"HasResult":true,"Error":false,"Key":"苹果","ElementCount":10,"Duty":{"duty_id":"1","name":"苹果","unit":"unit","price":100,"relatedwords":"apple","rate":0.01,"type":{"type":99,"name":"nameGoods_Type","midname":"midnameGoods_Type","overname":"overnameGoods_Type"},"limits":3,"grade":2},"SearchTakes":["苹果","梨子","香蕉"]}
        }
    }
}
