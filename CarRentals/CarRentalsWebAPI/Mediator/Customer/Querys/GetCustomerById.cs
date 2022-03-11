using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetCustomerById : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public GetCustomerById(int id)
        {
            Id = id;
        }
        public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetCustomerByIdHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetAsync(request.Id);
                return (customer == null) ? null : _mapper.Map<CustomerDto>(customer);
            }
        }
    }

}
