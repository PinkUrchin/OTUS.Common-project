using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace UfaData
{
    public enum ShapeType
    { 
        Point = 0,
        Line = 1, 
        Polygon = 2
    }
    
    public class Primitive
    {
        [Column(TypeName = "Id")]
        public int Id { get; set; }

        [Column(TypeName = "DocumentId")]
        public int DocumentId { get; set; }

        [Column(TypeName = "Shape")]
        public ShapeType Shape { get; set; }

        [Column(TypeName = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "CreateAuthor")]
        public string CreateAuthor { get; set; } = string.Empty;

        [Column(TypeName = "UpdateAuthor")]
        public string UpdateAuthor { get; set; } = string.Empty;

        [Column(TypeName = "Red")]
        public byte Red { get; set; }

        [Column(TypeName = "Green")]
        public byte Green { get; set; }

        [Column(TypeName = "Blue")]
        public byte Blue { get; set; }
    }
}