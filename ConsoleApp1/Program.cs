using System;
using System.Linq;
using LibraryA;
using LibraryB;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextA ctxA = new ContextA();
            ctxA.Set<ModelA>().Add(new ModelA());
            ctxA.SaveChanges();

            ContextB ctxB = new ContextB();
            ctxB.Set<ModelB>().Add(new ModelB());
            ctxB.SaveChanges();

            ContextJoin ctxJoin = new ContextJoin(ctxA, ctxB);
            ctxJoin.Set<ModelB>().Add(new ModelB());
            ctxJoin.Set<ModelA>().Add(new ModelA());
            ctxJoin.SaveChanges();

            var crossQuery = ctxJoin.Set<ModelA>().Join(
                ctxJoin.Set<ModelB>(), t => t.Id, t => t.Id, (a, b) => new
                {
                    a.Name,
                    b.Date
                }).ToList();
            crossQuery.ForEach(t => Console.WriteLine($"Name: {t.Name}, Date: {t.Date}"));
        }
    }
}
