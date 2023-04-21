namespace WebApplication1.Utils;

public static class ColorConverter
{
    public static string MapInfoToHex(int mapInfo)
    {
        int red = mapInfo / 65536;
        int green = (mapInfo - red * 65536) / 256;
        int blue = mapInfo - red * 65536 - green * 256;

        return red.ToString("X") + green.ToString("X") + blue.ToString("X");
    }
}