using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace DataProvider
{
    public enum ShapeTypeEnum
    { 
        Point = 0,
        Line = 1, 
        Polygon = 2,
        Ellipse = 3
    }
    
    public class dw_shape
    {
        [Column(TypeName = "Id")]
        public int Id { get; set; }

        [Column(TypeName = "DocumentId")]
        public int DocumentId { get; set; }

        [Column(TypeName = "ShapeType")]
        public ShapeTypeEnum ShapeType { get; set; }

        [Column(TypeName = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "CreateAuthor")]
        public string CreateAuthor { get; set; } = string.Empty;

        [Column(TypeName = "UpdateAuthor")]
        public string UpdateAuthor { get; set; } = string.Empty;

        [Column(TypeName = "Color")]
        public string Color { get; set; } = string.Empty;

        [Column(TypeName = "Coords")]
        public string Coords { get; set; } = string.Empty;
    }
}