using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VAT
{
    public static class CompanyInnResolver
    {
        public static List<Tuple<string, string>> ResolveInnFile(string companyNamefile)
        {
            var companyNamelist = new List<Tuple<string, string>>();
            string[] lines = Regex.Split(companyNamefile, "\r\n");
            foreach (var line in lines)
            {
                var strings = line.Split('\t');

                var companyInn = strings[0].ToString();
                var companyName = strings[1].ToString();

                var item = new Tuple<string, string>(companyInn, companyName);

                companyNamelist.Add(item);
            }
            return companyNamelist;
        }

    }

}
