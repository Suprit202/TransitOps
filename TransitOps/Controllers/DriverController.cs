using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransitOps.Models;
using TransitOpsService.DataTransferObject;
using TransitOpsService.Services.IServices;

namespace TransitOps.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }

        private async Task<SelectList> GetStatusSelectListAsync(int? selectedValue = null)
        {
            var statuses = await _driverService.GetAllDriverStatusesAsync();
            return new SelectList(statuses, "Id", "Name", selectedValue);
        }


        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            var viewModels = _mapper.Map<IEnumerable<DriverViewModel>>(drivers);

            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.StatusList = await GetStatusSelectListAsync();

            return View(new DriverViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<DriverDto>(model);
                string currentUserId = "SystemAdmin";

                await _driverService.CreateDriverAsync(dto, currentUserId);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StatusList = await GetStatusSelectListAsync(model.StatusId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var driverDto = await _driverService.GetDriverByIdAsync(id);
            if (driverDto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<DriverViewModel>(driverDto);

            ViewBag.StatusList = await GetStatusSelectListAsync(viewModel.StatusId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DriverViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<DriverDto>(model);
                string currentUserId = "SystemAdmin";

                await _driverService.UpdateDriverAsync(dto, currentUserId);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StatusList = await GetStatusSelectListAsync(model.StatusId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _driverService.DeleteDriverAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
