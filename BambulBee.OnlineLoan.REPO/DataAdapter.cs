using BumbleBee.OnlineLoan.REPOSITORY.Interface;
using BumbleBee.OnlineLoan.REPOSITORY.Models;
using BumbleBee.OnlineLoan.REPOSITORY.Repository;
using System;

namespace BumbleBee.OnlineLoan.REPOSITORY
{
    public class DataAdapter : IDisposable
    {
        private bool disposedValue;

        private DataContext _context = new DataContext();

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #region customer
        private IGenericRepository<Customer> customerGenericRepository;

        public IGenericRepository<Customer> CustomerGenericRepository
        {
            get
            {
                if (this.customerGenericRepository == null)
                    this.customerGenericRepository = new GenericRepository<Customer>(_context);
                return customerGenericRepository;
            }
        }

        #endregion customer

        #region Product

        private IGenericRepository<Product> productGenericRepository;
        private IProductRepository productRepository;


        public IProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new ProductRepository(_context);
                return productRepository;
            }
        }
        public IGenericRepository<Product> ProductGenericRepository
        {
            get
            {
                if (this.productGenericRepository == null)
                    this.productGenericRepository = new GenericRepository<Product>(_context);
                return productGenericRepository;
            }
        }
        #endregion Prodcut

        #region Category
        private IGenericRepository<Category> categoryGenericRepository;

        public IGenericRepository<Category> CategoryGenericRepository
        {
            get
            {
                if (this.categoryGenericRepository == null)
                    this.categoryGenericRepository = new GenericRepository<Category>(_context);
                return categoryGenericRepository;
            }
        }

        #endregion Category
        #region User

        private IGenericRepository<User> IUserRepository;

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (this.IUserRepository == null)
                    this.IUserRepository = new GenericRepository<User>(_context);
                return IUserRepository;
            }
        }

        #endregion User

        #region Function

        private IGenericRepository<Function> IFunctionRepository;

        public IGenericRepository<Function> FunctionRepository
        {
            get
            {
                if (this.IFunctionRepository == null)
                    this.IFunctionRepository = new GenericRepository<Function>(_context);
                return IFunctionRepository;
            }
        }

        #endregion Function

        #region UserFunctionAllocation

        private IGenericRepository<UserFunctionAllocation> IUserFunctionAllocationRepository;

        public IGenericRepository<UserFunctionAllocation> UserFunctionAllocationRepository
        {
            get
            {
                if (this.IUserFunctionAllocationRepository == null)
                    this.IUserFunctionAllocationRepository = new GenericRepository<UserFunctionAllocation>(_context);
                return IUserFunctionAllocationRepository;
            }
        }

        #endregion UserFunctionAllocation

    }
}
