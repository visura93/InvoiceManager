using InvoiceManager.Models.DomainObjects;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Repository
{
    public class InvoiceRepository : IinvoiceRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
      
        public InvoiceRepository(string endpoint, string key, string databaseId, string collectionId)
        {
            _cosmosClient = new CosmosClient(endpoint, key);
            _container = _cosmosClient.GetContainer(databaseId, collectionId);
        }

        public async Task<ResponseResult> AddInvoiceAsync(Invoice invoice)
        {
            try
            {
                //passing values to the cosmos db

                var responce = await _container.CreateItemAsync(invoice, new PartitionKey(invoice.Id));
               
                return new ResponseResult() { IsError = false, Message = "Sucessfully Create invoice, invoice id : " + invoice.Id  };
            }
            catch (Exception ex)
            {
                // return error messages
                return new ResponseResult() { IsError = true, Message = ex.Message  };
            }

        }


        public async Task<ResponseResult> UpdateInvoiceAsync(Invoice invoice)
        {
            try
            {
                //passing values to the cosmos db
                ItemResponse<Invoice> itemResponse = await _container.ReadItemAsync<Invoice>(invoice.Id, new PartitionKey(invoice.Id));
                Invoice originalInvoice = itemResponse.Resource;
                originalInvoice.Date = invoice.Date;
                originalInvoice.Description = invoice.Description;
                originalInvoice.InvoiceItems = invoice.InvoiceItems;
                var responce = await _container.ReplaceItemAsync<Invoice>(originalInvoice, originalInvoice.Id, new PartitionKey(originalInvoice.Id));

                return new ResponseResult() { IsError = false, Message = "Sucessfully updated invoice, invoice id : " + invoice.Id };
            }
            catch (Exception ex)
            {
                // return error messages
                return new ResponseResult() { IsError = true, Message = ex.Message };

            }
        }
    }
}
