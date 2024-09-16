using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism_AggregateRoot;
using Tourism_DTO;
using Tourism_Repository;

namespace Tourism_Handler
{
    public class LocationHandler : ILocationHandler
    {
        private readonly ILocationRepository<Location> _locationRepository;
        private readonly IValidator<LocationDTO > _validator;
        public LocationHandler(ILocationRepository<Location> locationRepository, IValidator<LocationDTO> validator)
        {
            _locationRepository = locationRepository;
            _validator = validator;
        }

        public async Task<IActionResult> CreateLocationAsync(LocationDTO locationDto)
        {
            var validationResult = await _validator.ValidateAsync(locationDto);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(new
                {
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage)
                });
            }

            var location = new Location();
            location.MapFromDTO(locationDto);

            await _locationRepository.AddAsync(location);
            return new OkObjectResult(locationDto);
        }


        public void DeleteLocation(int id)
        {
            throw new NotImplementedException();
        }

        public LocationDTO GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDTO> GetLocations(string searchString)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(LocationDTO locationDto)
        {

            //List<string> validationErrors;

            //// Retrieve the location from the repository
            //var location = _locationRepository.GetByIdAsync(locationDto.Id);

            //// Map the DTO values to the Location entity
            //location.MapFromDTO(locationDto);

            //// Validate the updated location
            //if (!location.validate(out validationErrors))
            //{
            //    foreach (var error in validationErrors)
            //    {
            //        Console.WriteLine(error); // Or handle errors as required
            //    }
            //    return;
            //}

            //// If validation passes, update the location in the repository
            //_locationRepository.UpdateLocation(location);

        }

       //



        //public void DeleteLocation(int id)
        //{
        //    _locationRepository.DeleteLocation(id);
        //}

        //public LocationDTO GetLocationById(int id)
        //{
        //    //var location = _locationRepository.GetLocationById(id);

        //    //var locationDto = new LocationDTO();
        //    //return location == null ? null : location.MapToDTO(locationDto);
        //    ////return locationDto;
        //}

        //public IEnumerable<LocationDTO> GetLocations(string searchString)
        //{
        //    //var locations = _locationRepository.GetLocations(searchString);
        //    //return locations.Select(Location =>
        //    //{
        //    //    var locationDto = new LocationDTO();
        //    //    Location.MapToDTO(locationDto);
        //    //    return locationDto;

        //    //});
        //}

        //public void CreateLocation(LocationDTO locationDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }

}

