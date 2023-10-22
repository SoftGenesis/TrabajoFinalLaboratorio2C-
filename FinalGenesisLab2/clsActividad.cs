using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace FinalGenesisLab2
{
    internal class clsActividad
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private String CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BD_Clientes.mdb";
        private String Tabla = "Actividad";

        public void ComboA(ComboBox cmb) 
        {
            try
            {
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                cmb.DataSource = DS.Tables[Tabla];
                cmb.DisplayMember = "Nombre";
                cmb.ValueMember = "idActividad";

                conexion.Close();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString());
            }
        }

        public String Actividad(Int32 ida) 
        {
            try
            {
                String result = "";
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);
                if (DS.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows) 
                    {
                        if (Convert.ToInt32(fila["idActividad"]) == ida) 
                        {
                            result = Convert.ToString(fila["Nombre"]);
                        }
                    }
                }
                conexion.Close();
                return result;
            }
            catch (Exception e )
            {
                return e.ToString();
            }
        }
    }
}
