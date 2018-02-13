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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnnue_Click(object sender, EventArgs e)
        {
            getset mo = new getset();
            conexion da = new conexion();
            mo.cod_tip_per = int.Parse(txtid.Text);
            mo.descip_pers = txtdesc.Text;
            da.guardartipoper(mo);
            MessageBox.Show("Datos guradados!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            dgbtp.DataSource = oper.consultaconresul("select * from tipo_persona");
            dgbcargo.DataSource = oper.consultaconresul("select * from cargo");
            dgbe.DataSource = oper.consultaconresul("select * from empleado");
            dgbu.DataSource = oper.consultaconresul("select * from usuario");
        }

        private void dgbtp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgbtp.Rows[e.RowIndex];
            txtid.Text = act.Cells["cod_tipo_persona"].Value.ToString();
            txtdesc.Text = act.Cells["descr_tipo_persona"].Value.ToString();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        { try
            {
                conexion oper = new conexion();
                oper.consultasinreaultado("delete from tipo_persona where cod_tipo_persona =" + txtid.Text + " ");
                MessageBox.Show("Datos borrados!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            dgbtp.DataSource = oper.consultaconresul("select * from tipo_persona");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getset mo = new getset();
            conexion da = new conexion();
            mo.cod_cargo = int.Parse(txtidc.Text);
            mo.nomb_car = txtcargo.Text;
            mo.salario = int.Parse(txtsal.Text);
            da.guardarcargo(mo);
            MessageBox.Show("Datos Guardados");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexion oper = new conexion();
                oper.consultasinreaultado("delete from cargo where cod_cargo =" + txtidc.Text+ "");
                MessageBox.Show("Datos borrados!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgbcargo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgbcargo.Rows[e.RowIndex];
            txtidc.Text  = act.Cells["cod_cargo"].Value.ToString();
            txtcargo.Text = act.Cells["nomb_cargo"].Value.ToString();
            txtsal.Text = act.Cells["salario_cargo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            dgbcargo.DataSource = oper.consultaconresul("select * from cargo");

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnge_Click(object sender, EventArgs e)
        {
            getset mo = new getset();
            conexion da = new conexion();
            mo.cod_e  = int.Parse(txtidce.Text);
            mo.estado = txtest.Text;
            mo.tipo_p = int.Parse(txtide.Text);
            mo.c_c_c = int.Parse(txtidce.Text);
            da.guardarcargo(mo);
            MessageBox.Show("Datos Guardados");

        }

        private void btnrefe_Click(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            dgbcargo.DataSource = oper.consultaconresul("select * from empleado");

        }

        private void dgbe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgbe.Rows[e.RowIndex];
            txtide.Text  = act.Cells["cod_empleado"].Value.ToString();
            txtest.Text = act.Cells["estad_empleado"].Value.ToString();
            txtidp.Text  = act.Cells["tipo_persona_cod_tipo_persona"].Value.ToString();
            txtidce.Text  = act.Cells["cargo_cod_cargo"].Value.ToString();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtide.Text = "";
            txtest.Text = "";
            txtidp.Text = "";
            txtidce.Text = "";

        }

        private void btngu_Click(object sender, EventArgs e)
        {
            getset mo = new getset();
            conexion da = new conexion();
            mo.id_u = int.Parse(txtidu.Text);
            mo.pass = txtcont.Text;
            mo.username = txtnombu.Text;
            mo.e_c_e = int.Parse(txtidui.Text);            
            da.guardarusuario(mo);
            MessageBox.Show("Datos Guardados");

        }

        private void btnrefu_Click(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            dgbu.DataSource = oper.consultaconresul("select * from usuario");

        }

        private void dgbu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgbu.Rows[e.RowIndex];
            txtidu.Text = act.Cells["cod_usuario"].Value.ToString();
            txtcont.Text  = act.Cells["contra_usuario"].Value.ToString();
            txtnombu.Text = act.Cells["nomb_usuario"].Value.ToString();
            txtidui.Text = act.Cells["empleado_cod_empleado"].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion oper = new conexion();
            oper.consultasinreaultado("delete from usuario where cod_usuario =" + txtidu.Text + "");
            MessageBox.Show("Datos borrados!");

        }
    }
}
