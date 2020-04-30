using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VAT
{
    public class VatActions : VatInterface
{
        public List<VatModel> DeserializeVatModel(string json)
        {
            var data = JArray.Parse(json);

            var list = new List<VatModel>();

            foreach (var item in data)
            {
                var date = JsonConvert.DeserializeObject<DateTime>("\"\\/Date(" + item["dateTime"].Value<string>() + "000" + ")\\/\"");

                var price = item["cashTotalSum"].Value<string>();
                if (price.Equals("0"))
                    price = item["ecashTotalSum"].Value<string>();

                var doublePrice = price.Substring(0, price.Length - 2) + "." + price.Substring(price.Length - 2, 2);
                list.Add(new VatModel(date, item["requestNumber"].Value<string>(), item["user"].Value<string>() + " | ИНН:" + item["userInn"].Value<string>(), doublePrice));

            }

            return list;
        }
    }
}
