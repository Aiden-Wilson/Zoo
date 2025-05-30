using ZooManagment;

void ZooInterface()
{
    string text = "1. Добавить льва" + "\n" +
                  "2. Покормить животное" + "\n" +
                  "3. Посмотреть список животных" + "\n" +
                  "4. Выход";
    Console.WriteLine(text + "\n");
}

Zoo zoo = new Zoo();

while (true)
{
    ZooInterface();
    if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > 4)
    {
        Console.WriteLine("Ошибка, введите число из списка");
    }    
    switch (number)
    {
        case 1:
            Console.WriteLine("Введите имя животного " + "\n");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя не может быть null" + "\n");
                break;
            }
            else
            {
                zoo.AddAnimal(new Lion() { Name = name });
                Console.WriteLine("Животное успешно добавлено" + "\n");
            }
            break;
        case 2:
            if (zoo.AnimalsCount == 0)
            {
                Console.WriteLine("В зоопарке нету животны" + "\n");
                break;
            }    
            Console.WriteLine("Выберете животного из списка:");
            zoo.PrintAnimals();
            if(!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > zoo.AnimalsCount  )
            {
                Console.WriteLine("Ошибка: введённое значение не является числом или животного с таким номером не существует!" + "\n");
                break;
            }
            else
            {
                zoo.FeedAnimal(index - 1);
                Console.WriteLine("Животное накормлено" + "\n");
            }
                break;
        case 3:
            Console.WriteLine("Список животных:");
            zoo.PrintAnimals();
            Console.WriteLine();
            break;
        case 4:
            return;
    }
}