using Business.Interface;
using DataAccessor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IRepository<Customer> _baseRepository;

        public CustomerService(IRepository<Customer> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            var item = await _baseRepository.AddAsync(customer);
            return item;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _baseRepository.Entities.OrderByDescending(x => x.CustomerId).AsNoTracking().ToListAsync();
            return customers;
        }
    }
}
