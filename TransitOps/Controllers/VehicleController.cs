using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransitOps.Models;
using TransitOpsService.DataTransferObject;
using TransitOpsService.Services.IServices;

namespace TransitOps.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            var viewModels = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new VehicleViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<VehicleDto>(model);
                string currentUserId = "SystemAdmin";

                await _vehicleService.CreateVehicleAsync(dto, currentUserId);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
