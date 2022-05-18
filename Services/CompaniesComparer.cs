using BackEndProject.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Services
{
	public class CompaniesComparer : IEqualityComparer<CompanyDTO>
	{
		public bool Equals(CompanyDTO x, CompanyDTO y)
		{
			if (object.ReferenceEquals(x, y))
			{
				return true;
			}

			if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
			{
				return false;
			}

			return (x.ListingID == y.ListingID) && (x.CategoryID == y.CategoryID) && (x.Company == y.Company) && (x.Image_List == y.Image_List);

		}

		public int GetHashCode([DisallowNull] CompanyDTO obj)
		{
			if (obj == null)
            {
                return 0;
            }

            int listingId = obj.ListingID.GetHashCode();
            int category = obj.Company.GetHashCode();
            int company = obj.Company == null ? 0 : obj.Company.GetHashCode();
            int image = obj.Image_List == null ? 0 : obj.Image_List.GetHashCode();
            return listingId ^ category ^ company ^ image;
		}
	}
}
