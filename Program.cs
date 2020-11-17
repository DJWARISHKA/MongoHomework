using MongoDB.Driver;
using MongoHomework.Repositories;

namespace MongoHomework
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.DropDatabase("VeterinaryClinic");
            var pets = new Pets(client.GetDatabase("VeterinaryClinic"));
            if (pets.Count() == 0)
                Initializer.Initialize(pets);
            var vet = new VetClinic(pets);
            vet.Start();
        }
    }
}