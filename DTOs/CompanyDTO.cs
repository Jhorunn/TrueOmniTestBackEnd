using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.DTOs
{
	public class CompanyDTO
	{
		public int ListingID { get; set; }

		public string Company { get; set; }

		public string Image_List { get; set; }

		public int CategoryID { get; set; }

		public string Description { get; set; }
	}
}
