using System.Linq;
using ContratosApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContratosApi.Controllers {
    [ApiController]
    [Route ("v1/contracties")]
    public class ContractController : Controller {
        private readonly DataContext _context;

        public ContractController (DataContext context) {
            _context = context;
        }

        [HttpGet ("{id}")]
        public IActionResult GetById (int id) {
            var contract = _context.Contracts.Find (id);

            if (contract == null) {
                return NotFound ();
            }

            return Ok (contract);
        }

        [HttpGet]
        public IActionResult Get () {
            var contracts = _context.Contracts.ToList ();

            return Ok (contracts);
        }
    }
}