using BackEndProject.DTOs;
using BackEndProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.Utils;

namespace BackEndProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		public ICompaniesService CompaniesService { get; }

		public CompaniesController(ICompaniesService companiesService)
		{
			CompaniesService = companiesService;
		}


		[HttpGet]
		public async Task<ActionResult<CompanyDTO>> Get([FromQuery] PaginationDTO paginationDTO)
		{
			var companies = await CompaniesService.GetCompanies();
			HttpContext.InsertNewHeaders<CompanyDTO>(paginationDTO, companies.Count());
			return Ok(companies.PaginateListExtension(paginationDTO));
		}
	}
}
