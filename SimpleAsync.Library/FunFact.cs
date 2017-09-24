using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SimpleAsync.Library
{
    public class FunFact
    {
        public int Id { get; set; }
        public string Fact { get; set; }
        public List<string> Impacts { get; set; }

        public override string ToString()
        {
            return Fact;
        }
    }
}
