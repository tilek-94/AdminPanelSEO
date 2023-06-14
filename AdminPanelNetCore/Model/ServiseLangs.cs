using AdminPanelNetCore.EntityLayer.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model
{
    public class ServiseLangs : IEntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ServiceId { get; set; }
        public Service? service { get; set; }
        public int LangsId { get; set; }
        public Langs? langs { get; set; }

    }
}
