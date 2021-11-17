using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class EERojo : EEEstado
    {
        public override void ColorSemaforo(SemaforoGaraje SG, int autos)
        {
            if (autos <= 40)
            {
                SG.CambiarEstado(new EEVerde());
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
            return "Ingresaron los ultimos autos y ya no hay mas lugar";
        }

        public override string Luz()
        {
            return "3sema.jpg";
        }

    }
}
