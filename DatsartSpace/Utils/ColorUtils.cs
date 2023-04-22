using System.Drawing;

namespace DatsartSpace.Utils;

public static class ColorUtils
{
    public static string MapInfoToHex(int mapInfo)
    {
        int red = mapInfo / 65536;
        int green = (mapInfo - red * 65536) / 256;
        int blue = mapInfo - red * 65536 - green * 256;

        return red.ToString("X") + green.ToString("X") + blue.ToString("X");
    }

    public static int MixMapColors(int color1, int color2, int rate1 = 1, int rate2 = 1)
    {
        return (color1 * rate1) / (rate1 + rate2) + (color2 * rate2 / (rate1 + rate2));
        //return (color1 + color2) / 2;
    }

    public static (int, int, int) GetRgb(int mapInfo)
    {
        int red = mapInfo / 65536;
        int green = (mapInfo - red * 65536) / 256;
        int blue = mapInfo - red * 65536 - green * 256;

        return (red, green, blue);
    }

    public static bool EverySimilar(int color1, int color2, int delta)
    {
        var rgb1 = GetRgb(color1);
        var rgb2 = GetRgb(color2);

        return Math.Abs(rgb1.Item1 - rgb2.Item1) <= delta &&
               Math.Abs(rgb1.Item2 - rgb2.Item2) <= delta &&
               Math.Abs(rgb1.Item3 - rgb2.Item3) <= delta;
    }
    
    public static bool AnySimilar(int color1, int color2, int delta)
    {
        var rgb1 = GetRgb(color1);
        var rgb2 = GetRgb(color2);

        return Math.Abs(rgb1.Item1 - rgb2.Item1) <= delta ||
               Math.Abs(rgb1.Item2 - rgb2.Item2) <= delta ||
               Math.Abs(rgb1.Item3 - rgb2.Item3) <= delta;
    }

    public static ColorCount[] GetDominantColors(Bitmap image)
    {
        var colors = new List<int>();
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                var color = image.GetPixel(x, y);
                int r = color.R << 16;
                int g = color.G << 8;
                int b = color.B;
                int rgb = r + g + b;

                if (rgb != 16777215)
                    colors.Add(rgb);
            }
        }
    
        var grouped = colors.GroupBy(val => val).Select(group => new ColorCount
        {
            Color = group.Key,
            Count = group.Count()
        }).OrderByDescending(val => val.Count);
        var groupedArray = grouped.ToArray();
        
        return groupedArray;
    }
    
}

public class ColorCount
{
    public int Color { get; set; }
    public int Count { get; set; }
}