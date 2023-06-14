using AdminPanelNetCore.EntityLayer.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model
{
    public class OptionsTerminal : IEntityBase
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }

    }
}
