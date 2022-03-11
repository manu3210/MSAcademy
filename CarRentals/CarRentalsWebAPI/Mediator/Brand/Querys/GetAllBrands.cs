using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Models;
using CarRentalsWebAPI.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetAllBrands : IRequest<IEnumerable<BrandDto>> { }
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrands, IEnumerable<BrandDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public GetAllBrandsHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrandDto>> Handle(GetAllBrands request, CancellationToken cancellationToken)
        {
            var list = new List<BrandDto>();

            foreach (Brand item in await _brandRepository.GetAll())
            {
                list.Add(_mapper.Map<BrandDto>(item));
            }

            return list;
        }
    }
}
