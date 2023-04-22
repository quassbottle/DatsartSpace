namespace DatsartSpace;

public class Ballista
{
    public (double angleHorizontal, double angleVertical, double power) 
        CalculateProjectile(int targetX, int targetY, int valume)
    {
        // Константы
        const double gravity = 9.80665;
        const double pi = 3.1415926535898;
        const double massCoefficient = 0.001;

        // Исходные данные
        double startX = Math.Abs(250 / 2 - targetX);;
        double startY = targetY + 300;
        double projectileMass = 1; // Произвольно выбранная масса снаряда
        double initialSpeed = 0; // Начальная скорость, которую будем подбирать

        double angleHorizontal = Math.Atan(startX / startY);
        
        double lenght = Math.Sqrt(Math.Pow(startX, 2) + Math.Pow(startY, 2));

        double power = lenght * gravity * massCoefficient * valume / (2 * Math.Pow(
            Math.Sin(0.785398), 2));

        if (targetX < 250)
            angleHorizontal = -angleHorizontal;
        
        return (angleHorizontal * 180 / pi, 45, power);
    }
}