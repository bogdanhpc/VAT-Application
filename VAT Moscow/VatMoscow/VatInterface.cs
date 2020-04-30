using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace VAT
{
    interface VatInterface
    {
        List<VatModel> DeserializeVatModel(string json);
    }
}
