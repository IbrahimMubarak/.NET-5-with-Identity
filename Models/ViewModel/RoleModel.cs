using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_User.Models.ViewModel
{
    public class RoleModel
    {
        [Required]
        [StringLength(maximumLength:80,MinimumLength =3)]
        public string Name { get; set; }
    }
}
