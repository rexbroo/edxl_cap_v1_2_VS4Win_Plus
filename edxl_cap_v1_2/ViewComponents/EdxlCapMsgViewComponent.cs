using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace edxl_cap_v1_2.ViewComponents
{
    public class EdxlCapMsgViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public EdxlCapMsgViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
        int SelectedAlertIndex, string Alert_Identifier)
        {
            var items = await GetItemsAsync(SelectedAlertIndex, Alert_Identifier);
            return View(items);
        }
        private Task<List<EdxlCapMsg>> GetItemsAsync(int SelectedAlertIndex, string Alert_Identifier)
        {
            return db.EdxlCapMsg.Where(x => x.Alert_Identifier == Alert_Identifier &&
                                 x.AlertIndex <= SelectedAlertIndex).ToListAsync();
        }
    }
}
