namespace CityBike.Core;

public class AgeValidator
{
    public const int AdultAge = 18;

public bool IsAdult(DateOnly birthDate, DateOnly today)
{
    int age = today.Year - birthDate.Year;

    if (today < birthDate.AddYears(age))
    {
        age--;
    }

    return age >= AdultAge;
}
}
