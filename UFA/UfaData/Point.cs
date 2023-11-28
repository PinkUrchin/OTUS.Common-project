using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfaData
{
    public class Point
    {
        [Column(TypeName = "Id")]
        public int Id { get; set; }

        [Column(TypeName = "X")]
        public double X { get; set; }

        [Column(TypeName = "Y")]
        public double Y { get; set; }        
    }
}
