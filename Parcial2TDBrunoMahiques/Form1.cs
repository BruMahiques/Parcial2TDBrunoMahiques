using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EE;
using DAL;

namespace Parcial2TDBrunoMahiques
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            autos = DalAuto.ObtenerEspacioGaraje();
            label5.Text = (50-DalAuto.ObtenerEspacioGaraje()).ToString();
            CambiarImagen();


        }

        int autos;
        DALAutos DalAuto = new DALAutos();
        

        

        SemaforoGaraje _semaforoGaraje = new SemaforoGaraje();

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(textBox1.Text) + autos > 50)
            {
                MessageBox.Show("La cantidad de autos ingresada supera el espacio del garaje");
                textBox1.Text = "";
            }
            else
            {
                //autos = 50-DalAuto.ObtenerEspacioGaraje();
                autos += Convert.ToInt32(textBox1.Text);

                MessageBox.Show(_semaforoGaraje.Verificar_Cantidad_de_autos(autos));
                int espacio = Convert.ToInt32(50) - autos;
                label5.Text = espacio.ToString();
                CambiarImagen();
                DalAuto.EspacioGaraje( autos,_semaforoGaraje.Verificar_Cantidad_de_autos(autos));
                label5.Text= (50 - DalAuto.ObtenerEspacioGaraje()).ToString();
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (autos - Convert.ToInt32(textBox1.Text) < 0)
            {
                MessageBox.Show("La cantidad de autos ingresada no existe ya que no puede salir mas autos de los que hay en el garaje");
                textBox1.Text = "";
            }
            else
            {
                //autos = 50-DalAuto.ObtenerEspacioGaraje();
                autos -= Convert.ToInt32(textBox1.Text);
                MessageBox.Show(_semaforoGaraje.Verificar_Cantidad_de_autos(autos));
                int espacio = Convert.ToInt32(50) - autos;
                label5.Text = espacio.ToString();
                CambiarImagen();
                DalAuto.EspacioGaraje(autos, _semaforoGaraje.Verificar_Cantidad_de_autos(autos));
                label5.Text = (50 - DalAuto.ObtenerEspacioGaraje()).ToString();
                textBox1.Text = "";
            }
        }

        public void CambiarImagen()
        {
            string imagen = _semaforoGaraje.Luz_semaforo(autos);
            Image Sema = Image.FromFile(imagen);
            pictureBox1.Image = Sema;
        }
    }
}
