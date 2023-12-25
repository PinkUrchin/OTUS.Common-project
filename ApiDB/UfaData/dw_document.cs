using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfaData
{
    public class dw_document
    {
        [Column(TypeName = "Id")]
        public int Id { get; set; }

        [Column(TypeName = "Name")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "CreateAuthor")]
        public string? CreateAuthor { get; set; } = string.Empty;

        [Column(TypeName = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "UpdateAuthor")]
        public string? UpdateAuthor { get; set; } = string.Empty;                
    }
}


