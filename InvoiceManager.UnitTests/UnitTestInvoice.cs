using InvoiceManager.Api.Controllers;
using InvoiceManager.Models;
using InvoiceManager.Models.DomainObjects;
using InvoiceManager.Models.DTOs;
using InvoiceManager.Repository;
using InvoiceManager.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Configuration;

namespace InvoiceManager.UnitTests
{
    public class UnitTestInvoice
    {
        string _CosmosDBUrl;
        string _CosmosDBkey;
        string _CosmosDatabaseId;
        string _CosmosDBCollectionId;

        public UnitTestInvoice()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            _CosmosDBUrl = config.GetSection("_CosmosDBUrl").Value;
            _CosmosDBkey = config.GetSection("_CosmosDBkey").Value;
            _CosmosDatabaseId = config.GetSection("_CosmosDatabaseId").Value;
            _CosmosDBCollectionId = config.GetSection("_CosmosDBCollectionId").Value;
        }

        #region Add Invoice Unit tests scenarios


        [Fact]
        public void InvoiceManager_AddInvoice_Valid()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = num.ToString();
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.AddInvoiceAsync(oInvoiceDto).Result;


            Assert.True(!result.IsError);

        }

        [Fact]
        public void InvoiceManager_AddInvoice_TestIdIsRequired_Invalid()
        {


            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            //oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.AddInvoiceAsync(oInvoiceDto).Result;

            Assert.True(result.IsError);

        }
        [Fact]
        public void InvoiceManager_AddInvoice_AlreadyExistaTestIdEnter_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.AddInvoiceAsync(oInvoiceDto).Result;

            Assert.True(result.IsError);

        }
        [Fact]
        public void InvoiceManager_AddInvoice_DescriptionIsRequired_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            // oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.AddInvoiceAsync(oInvoiceDto).Result;

            Assert.True(result.IsError);

        }
        [Fact]
        public void InvoiceManager_AddInvoice_DateIsRequired_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            // oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.AddInvoiceAsync(oInvoiceDto).Result;

            Assert.True(result.IsError);

        }
        [Fact]
        public void InvoiceManager_AddInvoice_InvoiceItemsRequired_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            // oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.AddInvoiceAsync(oInvoiceDto).Result;

            Assert.True(result.IsError);

        }


        #endregion
        [Fact]
        public void InvoiceManager_UpdateInvoice_Valid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rhrfw";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.UpdateInvoiceAsync(oInvoiceDto).Result;


            Assert.True(!result.IsError);

        }

        [Fact]
        public void InvoiceManager_UpdateInvoice_TestIdIsRequired_Invalid()
        {


            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            //oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.UpdateInvoiceAsync(oInvoiceDto).Result;

            Assert.True(result.IsError);

        }

        [Fact]
        public void InvoiceManager_UpdateInvoice_DescriptionIsRequired_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            // oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.UpdateInvoiceAsync(oInvoiceDto).Result;

            Assert.True(!result.IsError);

        }
        [Fact]
        public void InvoiceManager_UpdateInvoice_DateIsRequired_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            // oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.UpdateInvoiceAsync(oInvoiceDto).Result;

            Assert.True(!result.IsError);

        }
        [Fact]
        public void InvoiceManager_UpdateInvoice_InvoiceItemsRequired_Invalid()
        {

            var sut = new InvoiceRepository(_CosmosDBUrl, _CosmosDBkey, _CosmosDatabaseId, _CosmosDBCollectionId);

            Invoice oInvoiceDto = new Invoice();
            oInvoiceDto.Description = "test Description";
            oInvoiceDto.Date = DateTime.Now;
            oInvoiceDto.Id = "rrwr";
            oInvoiceDto.InvoiceItems = new List<InvoiceItem>();
            // oInvoiceDto.InvoiceItems.Add(new InvoiceItem() { Amount = 100, Quantity = 10, TotalAmount = 100.0, UnitPrice = 200 });

            var result = sut.UpdateInvoiceAsync(oInvoiceDto).Result;

            Assert.True(!result.IsError);

        }

    }
}