using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitedLibraryAPI.Interfaces;

namespace UnitedLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAdresses() 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addresses = _addressRepository.GetAddresses();
            return Ok(addresses);
        }

        [HttpGet("{city}")]
        public IActionResult GetAddressesByCity(string city) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var addresses = _addressRepository.GetAddressesByCity(city);
            return Ok(addresses);
        }

/*        [HttpGet("{state}")]
        public IActionResult GetAddressesByState(string state)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var addresses = _addressRepository.GetAddressesByState(state);
            return Ok(addresses);
        }*/
    }
}
