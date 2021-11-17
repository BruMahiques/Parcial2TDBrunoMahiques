using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class SemaforoGaraje
    {

        EEEstado _estado;

        public SemaforoGaraje()
        {
            _estado = new EEVerde(); 

        }

        public void CambiarEstado(EEEstado estado)
        {
            _estado = estado;
        }

        public string Verificar_Cantidad_de_autos(int autos)
        {
            _estado.ColorSemaforo(this, autos);
            return _estado.VerificarAutos();
        }

        public string Luz_semaforo(int autos)
        {
            _estado.ColorSemaforo(this, autos);
            return _estado.Luz();
        }

    }
}
