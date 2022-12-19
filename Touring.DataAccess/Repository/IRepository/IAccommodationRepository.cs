using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.Models;

namespace Touring.DataAccess.Repository.IRepository
{
    public interface IAccommodationRepository : IRepository<Accommodation>
    {
        IEnumerable<SelectListItem> ListForDropDown(int tourId);
    }
}
