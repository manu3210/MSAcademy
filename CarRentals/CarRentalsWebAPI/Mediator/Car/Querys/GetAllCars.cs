﻿using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using CarRentalsWebAPI.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetAllCars : IRequest<IEnumerable<CarDto>> { }
    public class GetAllCarsHandler : IRequestHandler<GetAllCars, IEnumerable<CarDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetAllCarsHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarDto>> Handle(GetAllCars request, CancellationToken cancellationToken)
        {
            var list = new List<CarDto>();

            foreach (Car item in await _carRepository.GetAll())
            {
                list.Add(_mapper.Map<CarDto>(item));
            }

            return list;
        }
    }
}
