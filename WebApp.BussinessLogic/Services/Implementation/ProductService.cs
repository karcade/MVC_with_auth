using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Model;
using WebApp.BussinessLogic.Services.Interfaces;
using WebApp.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApp.Common.ViewModels;

namespace WebApp.BussinessLogic.Services.Implementation
{
    public class ProductService: IProductService
    {
        public readonly ApplicationContext _db;
        public readonly IMapper _mapper;
        public readonly Parser.Parser _parser;
        public ProductService(ApplicationContext db) => _db = db;

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.AsNoTracking().ToList();
        }

        public Product Get(int id)
        {
            return _db.Products.FirstOrDefault(d => d.Id == id);
        }

        public void Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            if (!_db.Products.Any(d => d.Id == product.Id))
            {
                return;
            }
            _db.Update(product);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Products.Remove(_db.Products.FirstOrDefault(d => d.Id == id));
            _db.SaveChanges();
        }

        public void AddTask()
        {
            var products = _parser.GetProductModel();

            foreach (var product in products)
            {
                var Product = _mapper.Map<ProductModel, Product>(product);

                _db.Products.Add(Product);
                _db.SaveChanges();
            }
        }
    }
}
