namespace DatsartSpace;

public class Ballista
{
    const double Gravity = 9.80665;
    const double Pi = 3.1415926535898;
    const double MassCoefficient = 0.001;
    
    public (double angleHorizontal, double angleVertical, double power) 
        CalculateProjectile(int targetX, int targetY, int valume)
    {
        // Константы

        // Исходные данные
        double startX = Math.Abs(250 / 2 - targetX);;
        double startY = targetY + 300;
        double projectileMass = 1; // Произвольно выбранная масса снаряда
        double initialSpeed = 0; // Начальная скорость, которую будем подбирать

        double angleHorizontal = Math.Atan(startX / startY);
        
        double lenght = Math.Sqrt(Math.Pow(startX, 2) + Math.Pow(startY, 2));

        double power = lenght * Gravity * MassCoefficient * valume / (2 * Math.Pow(
            Math.Sin(0.785398), 2));

        if (targetX < 250)
            angleHorizontal = -angleHorizontal;
        
        return (angleHorizontal * 180 / Pi, 45, power);
    }

    public class DataForResearch
    {
        public (int x, int y) Position { get; set; }
        public int Volume { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
    }

    public class DataForCatapult
    {
        public double Power { get; set; }
        public double AngleVertical { get; set; }
        public double AngleHorizontal { get; set; }
    }

    public DataForCatapult Research(DataForResearch data)
    {
        int relativeX = Math.Abs(data.MaxX / 2 - data.Position.x);
        int relativeY = data.Position.y + 300;

        double angleHorizontal = Math.Atan((double)relativeX / relativeY);
        double length = Math.Sqrt(Math.Pow(relativeX, 2) + Math.Pow(relativeY, 2));

        double power = length * Gravity * MassCoefficient * data.Volume / (2 * Math.Pow(Math.Sin(0.785398), 2));
        if (data.Position.x < data.MaxX)
            angleHorizontal = -angleHorizontal;

        return new DataForCatapult()
        {
            Power = power,
            AngleHorizontal = (angleHorizontal * 180 / Pi),
            AngleVertical = 45
        };
    }

    public (double angleH, double angleV, double power) Calculate(int x, int y, int mass, int width)
    {
        double a = width / 2 - x;
        double b = 300 + y;

        double theta = Math.Atan(a / b);
        double angle = theta * (180 / Pi);
        double currentAngleHorizontal = angle;

        double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        double power = (Gravity * distance * mass * MassCoefficient) / 2;

        currentAngleHorizontal = x < a ? -currentAngleHorizontal : currentAngleHorizontal;
        
        return (currentAngleHorizontal, 45, power);
    }
}