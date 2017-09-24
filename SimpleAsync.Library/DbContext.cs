using System;
using System.Data.Entity;

namespace SimpleAsync.Library
{
    public class SimpleDb : DbContext
    {

        public DbSet<FunFact> FunFacts { get; set; }

    }
}
