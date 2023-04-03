using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.REPOSITORY;
using System;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.BUSINESS
{
    public class CustomerBL
    {
        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> lstCustomerModel = new List<CustomerModel>();

            try
            {
                using (DataAdapter dataAdapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Customer, CustomerModel>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    lstCustomerModel = iMapper.Map<List<Customer>, List<CustomerModel>>(dataAdapter.CustomerGenericRepository.GetAll());
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return lstCustomerModel;
        }
    }
}