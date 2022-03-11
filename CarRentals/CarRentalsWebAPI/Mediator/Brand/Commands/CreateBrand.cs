using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class CreateBrand : IRequest<BrandDto>
    {
        public BrandDto Brand { get; set; }

        public CreateBrand(BrandDto brand)
        {
            Brand = brand;
        }
        public class CreateBrandHandler : IRequestHandler<CreateBrand, BrandDto>
        {
            private readonly IBrandService _brandService;
            private readonly IMapper _mapper;
            public CreateBrandHandler(IBrandService brandService, IMapper mapper)
            {
                _brandService = brandService;
                _mapper = mapper;   
            }

            public async Task<BrandDto> Handle(CreateBrand request, CancellationToken cancellationToken)
            {
                return _mapper.Map<BrandDto>(await _brandService.CreateAsync(_mapper.Map<Brand>(request.Brand)));
            }
        }
    }

}
