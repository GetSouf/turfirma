class TravelItem
{
    public virtual string GetFullInfo()
    {
        return "Этот элемент заказа не имеет информации.";
    }
}

class Client : TravelItem
{
    private string name;
    private string surname;
    private int age;

    public Client()
    {
        Console.WriteLine("Добрый день, приветствуем вас на нашем международном портале авиаперелетов.");
        Console.ReadKey();
        Console.WriteLine("Вам необходимо зарегистрироваться.");
        Console.ReadKey();
        Console.WriteLine("Введите имя :");
        name = Console.ReadLine();
        Console.WriteLine("Введите фамилию :");
        surname = Console.ReadLine();
        Console.WriteLine("Введите возраст :");
        age = int.Parse(Console.ReadLine());
        if (age < 18)
        {
            Console.WriteLine("Лица младше 18 должны быть в сопровождении родителей");
        }
    }

    public override string GetFullInfo()
    {
        return $"Имя - {name}, Фамилия - {surname}, Возраст - {age}";
    }
}

class Order : TravelItem
{
    private string country;
    private int price;

    public Order()
    {
        Console.WriteLine("Куда летим?");
        country = Console.ReadLine();
        if (country == "Польша")
        {
            price = 1000;
        }
        else if (country == "Франция")
        {
            price = 800;
        }
        else if (country == "Чехия")
        {
            price = 900;
        }
        else
        {
            Console.WriteLine("Вам необходимо выбрать страну из предложенного списка");
        }
    }

    public override string GetFullInfo()
    {
        return $"Вы летите в страну - {country}, Стоимость перелета - {price}";
    }
}

class Hotel : TravelItem
{
    private int numberOfRooms;
    private int price;
    private int days;
    private int countOfBreakfast;

    public Hotel()
    {
        Console.WriteLine("На сколько дней вы хотите снять отель?");
        days = int.Parse(Console.ReadLine());
        Console.WriteLine("Нуждаетесь ли в ежедневном завтраке? Его стоимость составляет 100/день.");
        Console.WriteLine("Если да - нажмите 1, если нет - нажмите 0.");
        int helpBreakfast = int.Parse(Console.ReadLine());
        if (helpBreakfast == 1)
        {
            Console.WriteLine("Сколько завтраков вам необходимо?");
            countOfBreakfast = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Какое количество комнат вам необходимо.");
        numberOfRooms = int.Parse(Console.ReadLine());
        if (numberOfRooms == 2)
        {
            price = 500;
        }
        else if (numberOfRooms == 1)
        {
            price = 400;
        }
        else if (numberOfRooms == 3)
        {
            price = 600;
        }
    }

    public override string GetFullInfo()
    {
        if (countOfBreakfast > 0)
        {
            return $"Вы будете заселены в {numberOfRooms} комнатный номер на {days} дней, стоимость проживания с завтраками - {(countOfBreakfast * 100) + (days * price)}";
        }
        else
        {
            return $"Вы будете заселены в {numberOfRooms} комнатный номер на {days} дней, стоимость проживания без завтраков - {days * price}";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TravelItem[] items = new TravelItem[3];
        items[0] = new Client();
        items[1] = new Order();
        items[2] = new Hotel();

        Console.WriteLine("Вы желаете получить отчёт о заказе?");
        Console.WriteLine("Если желаете, нажмите 1, если нет, нажмите 0");
        int question = int.Parse(Console.ReadLine());
        if (question == 1)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.GetFullInfo());
            }
        }
        else
        {
            Console.WriteLine("Работа программы завершена");
        }
    }
}