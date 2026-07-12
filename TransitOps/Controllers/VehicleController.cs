using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TransitOps.Attributes;
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
        public async Task<IActionResult> Create()
        {
            var statuses = await _vehicleService.GetVehicleStatusesAsync();
            ViewBag.StatusList = new SelectList(statuses, "Id", "Name");
            var types = await _vehicleService.GetVehicleTypesAsync();
            ViewBag.TypeList = new SelectList(types, "Id", "Name");

            return View(new VehicleViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleDto = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicleDto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<VehicleViewModel>(vehicleDto);
            var statuses = await _vehicleService.GetVehicleStatusesAsync();
            ViewBag.StatusList = new SelectList(statuses, "Id", "Name", viewModel.StatusId);

            var types = await _vehicleService.GetVehicleTypesAsync();
            ViewBag.TypeList = new SelectList(types, "Id", "Name", viewModel.VehicleTypeId);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<VehicleDto>(model);

                string currentUserId = "SystemAdmin";

                await _vehicleService.UpdateVehicleAsync(dto, currentUserId);
                return RedirectToAction(nameof(Index));
            }

            var statuses = await _vehicleService.GetVehicleStatusesAsync();
            ViewBag.StatusList = new SelectList(statuses, "Id", "Name", model.StatusId);

            var types = await _vehicleService.GetVehicleTypesAsync();
            ViewBag.TypeList = new SelectList(types, "Id", "Name", model.VehicleTypeId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return RedirectToAction(nameof(Index));
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
