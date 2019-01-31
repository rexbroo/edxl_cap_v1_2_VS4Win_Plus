using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace edxl_cap_v1_2.Models.ContentViewModels
{
    public class EdxlCapMessageViewModel
    {
        public EdxlCapMessageViewModel()
        {
        }

        public EdxlCapMessageViewModel(string v, object p)
        {
        }

        [Key]
        public int AlertIndex { get; set; }
        public string Alert_Identifier { get; set; }
        public int SelectedAlertIndex { get; set; }
        [NotMapped]
        public List<SelectListItem> Alert_Identifiers { get; set; }
        public List<AlertVm> Alerts { get; set; }

        public Alert Alert { get; set; }

        public Info Info { get; set; }

        public Area Area { get; set; }

        public Resource Resource { get; set; }
    }



}
