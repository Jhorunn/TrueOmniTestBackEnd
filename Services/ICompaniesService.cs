﻿using BackEndProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Services
{
	public interface ICompaniesService
	{
		Task<List<CompanyDTO>> GetCompanies();
	}
}
