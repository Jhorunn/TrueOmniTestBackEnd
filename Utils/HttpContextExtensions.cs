using BackEndProject.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Utils
{
	public static class HttpContextExtensions
	{
		public static void InsertNewHeaders<T>(this HttpContext httpContext, PaginationDTO paginationDTO, int total)
		{
			if(httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

			httpContext.Response.Headers.Add("total", total.ToString());
			httpContext.Response.Headers.Add("page", paginationDTO.Page.ToString());
			httpContext.Response.Headers.Add("recordsPerPage", paginationDTO.ReccordsPerPage.ToString());
		}
	}
}
