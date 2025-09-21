public class Plant
{
    private string _name;
    private int _age;
    private double _height;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва не може бути порожньою.");
            if (value.Length < 2 || value.Length > 50)
                throw new ArgumentException("Назва повинна містити від 2 до 50 символів.");
            if (!value.All(c => char.IsLetter(c) || c == ' '))
                throw new ArgumentException("Назва може містити лише літери та пробіли.");
            _name = value;
        }
    }

    public PlantType Type { get; set; }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 5000)
                throw new ArgumentException("Вік повинен бути в діапазоні від 0 до 5000 років.");
            _age = value;
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            if (value <= 0 || value > 115.7)
                throw new ArgumentException("Висота повинна бути в діапазоні від 0 до 115.7 м (рекорд Hyperion).");
            _height = value;
        }
    }

    public DateTime PlantingDate { get; set; }

    public Plant(string name, PlantType type, int age, double height, DateTime plantingDate)
    {
        Name = name;
        Type = type;
        Age = age;
        Height = height;
        PlantingDate = plantingDate;
    }

    public string GetDescription()
    {
        return $"{Name} — це {Type.ToString().ToLower()}, віком {Age} років.";
    }

    public void Grow(double growth)
    {
        if (growth <= 0)
            throw new ArgumentException("Ріст повинен бути більше 0.");
        Height += growth;
        Console.WriteLine($"{Name} виріс на {growth}м. Нова висота: {Height}м");
    }

    public string GetPlantingInfo()
    {
        return $"{Name} було висаджено {PlantingDate:dd.MM.yyyy}.";
    }

    public bool IsMature()
    {
        return Age > 5;
    }
}