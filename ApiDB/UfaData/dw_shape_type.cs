using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfaData
{
    public class dw_shape_type
    {
        [Column(TypeName = "Id")]
        public int Id { get; set; }

        [Column(TypeName = "Name")]
        public string Name { get; set; } = string.Empty;
    }
}
