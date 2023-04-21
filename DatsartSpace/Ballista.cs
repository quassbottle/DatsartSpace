namespace DatsartSpace;

public class Ballista
{
    public (double angleHorizontal, double angleVertical, double power) 
        CalculateProjectile(double targetX, double targetY, double projectileMass, double paintArea)
    {
        const double gravity = 9.80665;
        const double pi = 3.1415926535898;
        const double massCoefficient = 0.001;

        // Calculate initial velocity based on the target coordinates and projectile mass
        double initialVelocity = Math.Sqrt(2 * gravity * targetY) / Math.Sin(pi / 4);

        // Calculate angle of elevation
        double angleVertical = Math.Atan((2 * targetY) / (initialVelocity * initialVelocity));

        // Calculate horizontal distance to target
        double targetDistance = targetX - (-300);

        // Calculate time of flight
        double timeOfFlight = targetDistance / (initialVelocity * Math.Cos(angleVertical));

        // Calculate maximum height reached
        double maxHeight = (initialVelocity * initialVelocity * Math.Sin(angleVertical) * Math.Sin(angleVertical)) / (2 * gravity);

        // Calculate angle of impact
        double angleImpact = Math.Atan((targetY - maxHeight) / targetDistance);

        // Calculate horizontal velocity
        double horizontalVelocity = initialVelocity * Math.Cos(angleVertical);

        // Calculate horizontal distance covered during descent
        //double descentDistance = (initialVelocity * Math.Sin(angleVertical) * timeOfFlight) - ((0.5) * gravity * timeOfFlight * timeOfFlight);

        // Calculate impact velocity
        double impactVelocity = Math.Sqrt((2 * gravity * (maxHeight - paintArea)) + (horizontalVelocity * horizontalVelocity));

        // Calculate angle of impact velocity
        double angleHorizontal = Math.Atan((impactVelocity * Math.Sin(angleImpact)) / (impactVelocity * Math.Cos(angleImpact)));

        // Calculate power based on projectile mass and volume
        double power = projectileMass * massCoefficient; // * projectileVolume;

        return (angleHorizontal, angleVertical, power);
    }
}