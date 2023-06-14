using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.Model.DtoModels
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public bool Flag { get; set; }
    }
}
