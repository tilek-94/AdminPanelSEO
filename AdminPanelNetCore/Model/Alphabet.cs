using AdminPanelNetCore.EntityLayer.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model
{
    public class Alphabet : IEntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }

    }
}
