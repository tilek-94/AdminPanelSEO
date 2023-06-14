using AdminPanelNetCore.EntityLayer.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model
{
    public class Branch : IEntityBase
    {
        public int Id { get; set; }
        public string? NameBranch { get; set; }
        public string? Address { get; set; }
        public int LangsId { get; set; }
        public Langs? langs { get; set; }

    }
}
