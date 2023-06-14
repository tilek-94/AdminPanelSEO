using AdminPanelNetCore.EntityLayer.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model
{
    public class Langs : IEntityBase
    {
        public int Id { get; set; }
        public string? Locale { get; set; }
        public int IsActive { get; set; }

    }
}
