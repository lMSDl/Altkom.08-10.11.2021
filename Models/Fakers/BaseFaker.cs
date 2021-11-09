using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Fakers
{
    public abstract class BaseFaker<T> : Faker<T> where T : class
    {
        protected BaseFaker() : base("pl")
        {
            StrictMode(true);
        }
    }
}
