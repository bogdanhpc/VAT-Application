using System.Collections.Generic;

namespace VAT
{
    public class JsonService : IJsonService<Vat>
    {
        private ICollection<Vat> _listOfChecks;
        public JsonService(ICollection<Vat> list)
        {
            ListOfChecks = list;
        }

        public ICollection<Vat> ListOfChecks { get => _listOfChecks; set => _listOfChecks = value; }
    }

}
