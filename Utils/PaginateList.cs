using BackEndProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Utils
{
	public static class PaginateList
	{
		public static List<T> PaginateListExtension<T>(this List<T> list, PaginationDTO paginationDTO)
		{
			return list
				.Skip((paginationDTO.Page - 1) * paginationDTO.ReccordsPerPage)
				.Take(paginationDTO.ReccordsPerPage)
				.ToList();
		}
	}
}
