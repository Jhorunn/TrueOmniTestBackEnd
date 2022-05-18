using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.DTOs
{
	public class PaginationDTO
	{
		public int Page { get; set; }
		private int recordsPerPage = 10;
		private readonly int maxRecordsPerPage = 30;

		public int ReccordsPerPage
		{
			get { return recordsPerPage; }

			set
			{
				recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
			}
		}

	}
}
