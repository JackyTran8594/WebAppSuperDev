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
    public interface ITypeProductService : IEntityServiceBase<TypeProduct>
    {
        void Insert(TypeProductViewModel.TypeProductDto TypeProduct);
        void Update(TypeProductViewModel.TypeProductDto TypeProduct, string id);
        TypeProductViewModel.TypeProductDto Detail(string id);
        void Delete(string id);
    }
    public class TypeProductService : EntityServiceBase<TypeProduct>, ITypeProductService
    {
        private string TypeProductCode = "Emp";

        public TypeProductService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Insert(TypeProductViewModel.TypeProductDto TypeProduct)
        {
            try
            {
                var data = new TypeProduct();
                if (TypeProduct != null)
                {
                    data = Mapper.Map<TypeProductViewModel.TypeProductDto, TypeProduct>(TypeProduct);
                    data.TypeCode = Guid.NewGuid().ToString();
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

        public void Update(TypeProductViewModel.TypeProductDto TypeProduct, string id)
        {
            try
            {
                if (TypeProduct != null)
                {
                    var data = Mapper.Map<TypeProductViewModel.TypeProductDto, TypeProduct>(TypeProduct);
                    UpdateService(data);
                    UnitOfWork.Save();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Sorry, Something went wrong!");
            }
        }

        public TypeProductViewModel.TypeProductDto Detail(string id)
        {
            var data = new TypeProductViewModel.TypeProductDto();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var exist = Repository.GetById(id);
                    data = Mapper.Map<TypeProduct, TypeProductViewModel.TypeProductDto>(exist);
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
