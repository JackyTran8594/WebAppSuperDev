using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TONYVU.ENTITY.API.DAL;
using TONYVU.ENTITY.API.Configuration;
using TONYVU.ENTITY.API.Helper;
using TONYVU.ENTITY.API.Repository;

namespace TONYVU.ENTITY.API.Service
{
    public interface IProductService : IEntityServiceBase<Product>
    {
        void Insert(ProductViewModel.ProductDto Product);
        void Update(ProductViewModel.ProductDto Product, string id);
        ProductViewModel.ProductDto Detail(string id);
        void Delete(string id);
    }
    public class ProductService : EntityServiceBase<Product>, IProductService
    {
        private string ProductCode = "Emp";

        public ProductService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(ProductViewModel.ProductDto Product)
        {
            try
            {
                var data = new Product();
                if (Product != null)
                {
                    data = Mapper.Map<ProductViewModel.ProductDto, Product>(Product);
                    data.Status = 10;
                    data.CreateDate = DateTime.Now;
                    InsertService(data); ;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public void Update(ProductViewModel.ProductDto Product, string id)
        {
            try
            {
                if (Product != null)
                {
                    var data = Mapper.Map<ProductViewModel.ProductDto, Product>(Product);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public ProductViewModel.ProductDto Detail(string id)
        {
            var data = new ProductViewModel.ProductDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<Product, ProductViewModel.ProductDto>(exist);
                    return data;
                }
            }
            catch (Exception exception)
            {
                return null;
            }
            return data;
        }

        public void Delete(string id)
        {
            var _id = Convert.ToInt32(id);
            try
            {
                Repository.Delete(_id);
                UnitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }
    }
}
