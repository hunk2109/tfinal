using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p4final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            string resultado = oper.conectar();
            MessageBox.Show(resultado);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            string resultado = oper.conectar();
            MessageBox.Show(resultado);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prueba; integrated security = true;");
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM USUARIO WHERE nomb_usuario='" + txtu.Text + "' AND contra_usuario='" + txtcon.Text + "'", cnx);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Form2 fmr = new Form2();
                    this.Hide();
                    fmr.ShowDialog();
                    this.Show();
                    txtu.Clear();
                    txtcon.Clear();


                    
                   
                }
                else
                    MessageBox.Show("Contraseña y Usuario incorrectos");
               
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally

            {
                
                
            }

        }
    }
}
