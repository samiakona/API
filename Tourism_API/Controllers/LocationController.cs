using Microsoft.AspNetCore.Mvc;
using Tourism_Handler;


using Tourism_DTO;
using Tourism_AggregateRoot;

namespace Tourism_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly LocationHandler _locationHandler;
        private readonly LocationValidator _locationDTOValidator;

        public LocationController(LocationHandler locationHandler, LocationValidator locationDTOValidator)
        {
            _locationHandler = locationHandler;
            _locationDTOValidator = locationDTOValidator;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Create(LocationDTO locationDTO)
        {
            // The handler method now handles validation and creation
         
            _locationHandler.CreateLocation(locationDTO);
            return View();
        }

        public IActionResult Edit(int id)
        {
            var location = _locationHandler.GetLocationById(id);
            //if (location == null) 
            //{
            //    return NotFound();
            //}
            return View();
        }

        [HttpPost]
        public IActionResult Edit(LocationDTO locationDto)
        {

            _locationHandler.UpdateLocation(locationDto);
            return View(locationDto);
        }


        public IActionResult Delete(int id)
        {
            var location = _locationHandler.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            _locationHandler.DeleteLocation(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var location = _locationHandler.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

    }
}
