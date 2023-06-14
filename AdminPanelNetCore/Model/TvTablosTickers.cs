using AdminPanelNetCore.EntityLayer.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model
{
    public class TvTablosTickers : IEntityBase
    {
        public int Id { get; set; }
        public string? MarqueeText { get; set; }
    }
}
