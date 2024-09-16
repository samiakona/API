using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism_DTO;

namespace Tourism_Handler
{
    public interface ILocationHandler
    {
        //void CreateLocation(LocationDTO locationDto);
        Task<IActionResult> CreateLocationAsync(LocationDTO locationDto);

        void DeleteLocation(int id);

        LocationDTO GetByIdAsync(int id);

        IEnumerable<LocationDTO> GetLocations(string searchString);

        void UpdateLocation(LocationDTO locationDto);
    }

}
