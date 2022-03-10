using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetAllCustomers : IRequest<IEnumerable<CustomerDto>> { }
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            var list = new List<CustomerDto>();

            foreach (Customer item in await _customerRepository.GetAll())
            {
                list.Add(new CustomerDto(item));
            }

            return list;
        }
    }
}
