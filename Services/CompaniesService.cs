using BackEndProject.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BackEndProject.Utils;

namespace BackEndProject.Services
{
	public class CompaniesService : ICompaniesService
	{
		private readonly HttpClient _httpClient;

		private const int total = 400;

		public CompaniesService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<CompanyDTO>> GetCompanies()
		{
			var companies = new List<CompanyDTO>();
			var apiUrl = "?domainid=2248&fn=listings";
			var response = await _httpClient.GetAsync(apiUrl);

			CompaniesComparer companiesComparer = new CompaniesComparer();

			if (response.IsSuccessStatusCode)
			{
				companies = await response.Content.ReadAsAsync<List<CompanyDTO>>();
			}

			companies = companies.Distinct(companiesComparer).ToList();

			int actual = companies.Count();
			int needed = total - actual;

			if(needed <= 0)
			{
				return companies.Take(total).ToList();
			}

			var newCompanies = new List<CompanyDTO>();
			int round;
			int j = 0;

			for (int i = 0; i < needed; i++)
			{
				round = i / actual + 1;

				if(i >= actual)
				{
					j = i - actual;
				}
				newCompanies.Add(new CompanyDTO
				{ 
					Company = $"{companies[j].Company} {round}", 
					CategoryID = companies[j].CategoryID, 
					Image_List = companies[j].Image_List, 
					ListingID = companies[j].ListingID 
				});
				j++;
			}

			companies.AddRange(newCompanies);

			return companies.OrderBy(x => x.ListingID).ToList();
		}

	}
}
