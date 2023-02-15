using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models.DomainObjects
{
    public class Invoice
    {
        [Required]
        [JsonProperty("id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        [Required]
        [JsonProperty("totalAmount")]
        public double TotalAmount { get; set; }
        [Required]
        [JsonProperty("invoiceItems")]
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
