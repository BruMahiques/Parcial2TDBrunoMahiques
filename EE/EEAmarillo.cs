using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class EEAmarillo : EEEstado
    {
        public override void ColorSemaforo(SemaforoGaraje SG, int autos)
        {
            if (autos == 50)
            {
                SG.CambiarEstado(new EERojo());
            }
            else
            {
                if (autos <= 40)
                {
                    SG.CambiarEstado(new EEVerde());
                }
            }
        }

        public override string VerificarAutos()
        {
            return "Pase, queda poco lugar";
        }

        public override string Luz()
        {
            return "2sema.jpg";
        }

    }
}
