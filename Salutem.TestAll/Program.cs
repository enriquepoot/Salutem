using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Salutem.DataAccess.Repositories;

namespace Salutem.TestAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new PersonRepository("Data Source=.;Initial Catalog=Salutem.Database;Integrated Security=True;Pooling=False");
            repo.Add(new Entities.Person { Name = "test", LastName="fdf" });
            var data = repo.GetAllWithDeleted();
            foreach (var item in data)
            {
                Console.WriteLine(item.Name);
            }
            var upd = data.FirstOrDefault();
            upd.Name = "Changed";
            repo.Update(upd);
            Console.WriteLine();
            data = repo.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            Console.WriteLine(repo.GetById(data.FirstOrDefault().ID).Name);
            Console.WriteLine();
            repo.Delete(data.Where(w => w.Name == "test").FirstOrDefault());
            Console.WriteLine();
            data = repo.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }
}
