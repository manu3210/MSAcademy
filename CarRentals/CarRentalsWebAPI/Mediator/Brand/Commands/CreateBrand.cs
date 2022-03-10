using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
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
            public CreateBrandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<BrandDto> Handle(CreateBrand request, CancellationToken cancellationToken)
            {
                return new BrandDto(await _brandService.CreateAsync(BrandDto.DtoToEntity(request.Brand)));
            }
        }
    }

}
