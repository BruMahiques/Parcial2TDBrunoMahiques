using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class EEVerde : EEEstado
    {
        public override void ColorSemaforo(SemaforoGaraje SG, int autos)
        {
            if (autos == 50)
            {
                SG.CambiarEstado(new EERojo());
            }
            else
            {
                if (autos > 40 && autos < 50)
                {
                    SG.CambiarEstado(new EEAmarillo());
                }
                
            }
        }

        public override string VerificarAutos()
        {
            return "Pase, queda mucho lugar";
        }

        public override string Luz()
        {
            return "1sema.jpg";
        }


    }
}
