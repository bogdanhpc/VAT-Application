using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VAT
{
    public static class JsonDeserializer
    {
        public static ICollection<Vat> Deserialize(string json, string textFile)
        {
            var companyNameList = CompanyInnResolver.ResolveInnFile(textFile);

            var data = JArray.Parse(json);

            ///var vatList = JsonConvert.DeserializeObject<List<Object>>(json);

            var list = new List<Vat>();



            foreach (var item in data)
            {
                var date = JsonConvert.DeserializeObject<DateTime>("\"\\/Date(" + item["dateTime"].Value<string>() + "000" + ")\\/\"");

                var price = item["cashTotalSum"].Value<string>();
                if (price.Equals("0"))
                    price = item["ecashTotalSum"].Value<string>();

                var doublePrice = price.Substring(0, price.Length - 2) + "." + price.Substring(price.Length - 2, 2);

                
                var userInn = item["userInn"].Value<string>() ?? "";

                var result = companyNameList.Find(x => x.Item1 == userInn);

                var companyName = string.Empty;

                if (result == null)
                {
                    companyName = "";
                }
                else
                {
                    companyName = result.Item2;
                }

                var obj = new Vat(date, "#" + item["requestNumber"].Value<string>(), companyName, userInn, doublePrice, "Продукты");
                list.Add(obj);
            }

            return list;
        }
    }

}
