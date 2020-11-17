using System;
using System.Text;
using MongoHomework.Repositories;

namespace MongoHomework
{
    internal class VetClinic
    {
        private readonly Pets _repository;

        public VetClinic(Pets repository)
        {
            _repository = repository;
        }

        public void Start()
        {
            while (Menu()) ;
        }

        private bool Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.WriteLine("Ветеринарная клиника");
            Console.WriteLine("1. Показать список животных");
            Console.WriteLine("2. Вывести отчет");
            Console.WriteLine("3. Выход");

            ConsoleKeyInfo key;
            while (!"123".Contains((key = Console.ReadKey(true)).KeyChar))
                Console.WriteLine("\nНеправильная кнопка\n");

            switch (key.KeyChar)
            {
                case '1':
                    ViewPets();
                    break;

                case '2':
                    PrintReport();
                    break;

                case '3':
                    return false;
            }

            return true;
        }

        private void ViewPets(int pageSize = 3)
        {
            if (pageSize < 1) return;
            var page = 0;
            var count = (int) _repository.Count() / pageSize;
            if (_repository.Count() % pageSize > 0) count++;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine($"Страница {page + 1} из {count}");
                Console.WriteLine();
                var pets = _repository.Search(page, pageSize);

                foreach (var pet in pets)
                {
                    Console.Write( //Что б табличка не сьехала, заместь Клички вывожу Имя
                        $"Имя: {pet.Name}\tВид: {pet.Kind}\tВладелец: {pet.Owner.Name}\tТелефон: {pet.Owner.Phone}\t");
                    Console.WriteLine($"Дата регистрации: {pet.Date:dd.MM.yyyy}");
                }

                Console.WriteLine("\n1. Следующая страница");
                Console.WriteLine("2. Предыдущая страница");
                Console.WriteLine("3. Выход");

                while (!"123".Contains((key = Console.ReadKey(true)).KeyChar))
                    Console.WriteLine("\nНеправильная кнопка\n");
                switch (key.KeyChar)
                {
                    case '1':
                        page = (page + 1) % count;
                        break;
                    case '2':
                        page = (page - 1) % count;
                        page = page < 0 ? count - 1 : page;
                        break;
                }
            } while (key.KeyChar != '3');
        }

        private void PrintReport()
        {
            var data = _repository.GetReport();
            Console.Clear();
            Console.WriteLine("Отчет");
            Console.WriteLine("Начало\n");
            foreach (var group in data)
                Console.WriteLine($"{group.Key}: {group.Count} особей");
            Console.WriteLine();
            Console.WriteLine("Конец");

            Console.WriteLine("Нажмите Еnter для выхода");
            Console.ReadLine();
        }
    }
}