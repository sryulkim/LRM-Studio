using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace HMIProject
{
    public static class StaticMethods
    {
        public static List<ConditionEvent> condtionEventList = new List<ConditionEvent>();
        public static List<HMIEditorPane> hmIEditorPaneList = new List<HMIEditorPane>();

        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}
