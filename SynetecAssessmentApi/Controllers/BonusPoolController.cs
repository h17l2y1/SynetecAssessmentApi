using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SynetecAssessmentApi.BLL.Dtos;
using SynetecAssessmentApi.BLL.Services.Interfaces;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;

        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bonusPoolService.GetEmployeesAsync();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            var response = await _bonusPoolService.CalculateAsync(request.TotalBonusPoolAmount, request.SelectedEmployeeId);
            return Ok(response);
        }
    }
}
