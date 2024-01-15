using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XamlVectorGraphicEditor.MyShapesDTO
{
    public class AbstractShapeDTO
    {
        protected static readonly Random _random = new Random(DateTime.Now.Millisecond);

        public static System.Windows.Media.Color RandomColor()
        {
            var colors = new List<System.Windows.Media.Color>();
            foreach (var inf in typeof(Brushes).GetProperties(BindingFlags.Static | BindingFlags.Public))
                colors.Add((inf.GetValue(null) as SolidColorBrush).Color);
            
            return colors[_random.Next(colors.Count)];
        }
    }
}
