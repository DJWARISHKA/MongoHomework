using System;
using MongoHomework.Entities;
using MongoHomework.Repositories;

namespace MongoHomework
{
    public static class Initializer
    {
        private static readonly string[] _names = new string[30]
        {
            "Федосий", "Ирина", "Виталий", "Софья  ", "Лев   ", "Ангелина", "Николай", "Эмилия", "Илья  ", "Алина ",
            "Юлий  ", "Нона  ", "Филипп", "Светлана", "Вячеслав", "Дина  ", "Мечислав", "Владлена", "Игнат  ", "Аза   ",
            "Аким  ", "Полина", "Вадим", "Владислава", "Тимофей", "Вероника", "Лавр  ", "Маргарита", "Евстигней",
            "Изабелла"
        };

        public static void Initialize(Pets repository)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < 13; i++)
                repository.Insert(new Pet
                {
                    Name = _names[rand.Next(0, 30)],
                    Kind = (PetKind) rand.Next(0, 3),
                    Date = new DateTime(2020, rand.Next(1, 13), rand.Next(1, 29)),
                    Owner = new Owner
                    {
                        Name = _names[rand.Next(0, 30)],
                        Phone = "+380" + rand.Next(100000000, 999999999)
                    }
                });
        }
    }
}