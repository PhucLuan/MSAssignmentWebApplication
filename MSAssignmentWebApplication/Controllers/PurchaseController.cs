using Business.Interface;
using Business.Service;
using DataAccessor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MSAssignmentWebApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [Route("GetPurchasesData")]
        [HttpGet]
        public async Task<ActionResult> GetPurchasesData(string? productName)
        {
            try
            {
                var results = await _purchaseService.GetPurchasesData(productName);
                return Ok(results);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
