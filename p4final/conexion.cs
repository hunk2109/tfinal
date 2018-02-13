using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace p4final
{
    class conexion
    {
        SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prueba; integrated security = true;");

        public void guardartipoper(getset mo)
        {
            string strl = "insertartip";
            SqlCommand cmd = new SqlCommand(strl, cnx);
            cnx.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_t_per", mo.cod_tip_per);
            cmd.Parameters.AddWithValue("@des_tipo_pers", mo.descip_pers);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public void guardarcargo(getset mo)
        {
            string strl = "guardarcargo";
            SqlCommand cmd = new SqlCommand(strl, cnx);
            cnx.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_c", mo.cod_cargo);
            cmd.Parameters.AddWithValue("@nom_ca", mo.nomb_car);
            cmd.Parameters.AddWithValue("@sal_c", mo.salario);
            cmd.ExecuteNonQuery();
            cnx.Close();

        }

        public void guardarempl(getset mo)
        {
            string strl = "guardaremp";
            SqlCommand cmd = new SqlCommand(strl, cnx);
            cnx.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("code", mo.cod_e);
            cmd.Parameters.AddWithValue("estaem", mo.estado);
            cmd.Parameters.AddWithValue("tipop", mo.tipo_p);
            cmd.Parameters.AddWithValue("codc", mo.c_c_c);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public void guardarusuario(getset mo)
        {
            string strl = "guardarusario";
            SqlCommand cmd = new SqlCommand(strl, cnx);
            cnx.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_u", mo.id_u);
            cmd.Parameters.AddWithValue("@contr_u",mo.pass);
            cmd.Parameters.AddWithValue("@nomb_u", mo.username);
            cmd.Parameters.AddWithValue("@e_c_e", mo.e_c_e);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public string conectar()
        {
            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prueba; integrated security = true;");
            try
            {
                cnx.Open();
                return "conxion exitosa!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                cnx.Close();
            }

        }

        public string consultasinreaultado(string sql)
        {
            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prueba; integrated security = true;");
            try
            {
                cnx.Open();
                SqlCommand comand = new SqlCommand(sql, cnx);
                comand.ExecuteNonQuery();
                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cnx.Close();
            }
        }
        public DataTable consultaconresul(string sql)
        {
            SqlDataAdapter ad;
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prueba; integrated security = true;");
            try
            {
                cnx.Open();
                SqlCommand cmd;
                cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);


            }

            cnx.Close();
            return dt;
        }
    }
}
