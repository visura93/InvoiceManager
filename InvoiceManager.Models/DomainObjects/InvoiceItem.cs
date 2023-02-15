using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models.DomainObjects
{
    public class InvoiceItem
    {

        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unitPrice")]
        public double UnitPrice { get; set; }
        [JsonProperty("totalAmount")]
        public double TotalAmount { get; set; }
    }
}
