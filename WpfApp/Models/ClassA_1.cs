using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    //Klasa podzielona na 2 pliki wymaga:
    //- słowa kluczowego partial
    //- tej samej nazwy klasy w obu plikach
    //- tej samej przestrzeni nazw
    //- pliku muszą znajdować się w tym samym assembly (projekcie)

    public partial class ClassA
    {
        public void Execure()
        {
            Name = "Hello!";
        }
    }
}
