using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public abstract class EEEstado
    {
        public abstract void ColorSemaforo(SemaforoGaraje SG, int autos);

        public abstract string VerificarAutos();

        public abstract string Luz();



    }
}
