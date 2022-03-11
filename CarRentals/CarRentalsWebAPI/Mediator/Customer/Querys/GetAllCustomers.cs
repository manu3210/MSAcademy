using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetAllCustomersHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            var list = new List<CustomerDto>();

            foreach (Customer item in await _customerRepository.GetAll())
            {
                list.Add(_mapper.Map<CustomerDto>(item));
            }

            return list;
        }
    }
}
