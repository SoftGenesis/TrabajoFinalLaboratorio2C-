using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;


namespace FinalGenesisLab2
{
    internal class clsSocio
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private String CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BD_Clientes.mdb";
        private String Tabla = "Socio";

        clsBarrio b = new clsBarrio();
        clsActividad a = new clsActividad();
        Image img;

        private Int32 cant;
        private Decimal TotDeu;
        private Decimal Prom;

        private Int32 IdSoc;
        private String Nom;
        private String Dir;
        private Int32 IdBar;
        private Int32 IdAct;
        private Decimal Deu;

        public Int32 IdSocio
        {
            get { return IdSoc; }
            set { IdSoc = value; }
        }

        public String Nombre
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public String Direccion
        {
            get { return Dir; }
            set { Dir = value; }
        }

        public Int32 IdBarrio
        {
            get { return IdBar; }
            set { IdBar = value; }
        }

        public Int32 IdActividad
        {
            get { return IdAct; }
            set { IdAct = value; }
        }

        public Decimal Deuda
        {
            get { return Deu; }
            set { Deu = value; }
        }

        public Int32 Cantidad
        {
            get { return cant; }
        }

        public Decimal TotalDeuda
        {
            get { return TotDeu; }
        }

        public Decimal Promedio
        {
            get { return Prom; }
        }



        public void Agregar()
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
                DataTable tabla = DS.Tables[Tabla];
                DataRow fila = tabla.NewRow();
                fila["IdSocio"] = IdSoc;
                fila["Nombre"] = Nom;
                fila["Direccion"] = Dir;
                fila["idBarrio"] = IdBar;
                fila["idActividad"] = IdAct;
                fila["Deuda"] = Deu;
                tabla.Rows.Add(fila);
                OleDbCommandBuilder ConciliaCambios = new OleDbCommandBuilder(adaptador);
                adaptador.Update(DS, Tabla);

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Buscar(Int32 id, ComboBox cmbB, ComboBox cmbA)
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

                if (DS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(fila["IdSocio"]) == id)
                        {
                            IdSoc = Convert.ToInt32(fila["IdSocio"]);
                            Nom = Convert.ToString(fila["Nombre"]);
                            Dir = Convert.ToString(fila["Direccion"]);
                            cmbB.SelectedIndex = Convert.ToInt32(fila["idBarrio"]);
                            cmbA.SelectedIndex = Convert.ToInt32(fila["idActividad"]);
                            Deu = Convert.ToDecimal(fila["Deuda"]);
                        }
                    }
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Modificar(clsSocio Socio, Int32 IdSocio)
        {
            try
            {
                String sql = "";
                sql = $"UPDATE Socio SET Direccion = ' { Socio.Dir } ', idBarrio = ' { Socio.IdBar } ', idActividad = ' { Socio.IdAct } ', Deuda = ' { Socio.Deu } ' WHERE IdSocio =" + IdSocio.ToString();
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void Eliminar(Int32 IdSoci)
        {
            try
            {
                String sql = "DELETE * FROM Socio WHERE IdSocio = " + IdSoci.ToString();
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Consultar(String nom, Label lblB, Label lblA)
        {
            try
            {
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                OleDbDataReader DR = comando.ExecuteReader();
                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        if (DR.GetString(1) == nom)
                        {
                            IdSoc = DR.GetInt32(0);
                            Dir = DR.GetString(2);
                            lblB.Text = b.Barrio(DR.GetInt32(3));
                            lblA.Text = a.Actividad(DR.GetInt32(4));
                            Deu = DR.GetDecimal(5);
                        }
                    }
                }
                DR.Close();
                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ListarTodo(DataGridView dgv)
        {
            try
            {
                String Barrio = "";
                String Actividad = "";
                cant = 0;
                TotDeu = 0;

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                dgv.Rows.Clear();
                if (DS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                        Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));

                        dgv.Rows.Add(fila["IdSocio"], fila["Nombre"], Barrio, Actividad, Convert.ToDecimal(fila["Deuda"]));
                        cant++;
                        TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                    }
                }

                conexion.Close();
                Prom = TotDeu / cant;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void ListarDe(DataGridView dgv)
        {
            try
            {
                cant = 0;
                TotDeu = 0;
                String Actividad = "";
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                dgv.Rows.Clear();
                if (DS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToDecimal(fila["Deuda"]) > 0)
                        {
                            Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                            dgv.Rows.Add(fila["IdSocio"], fila["Nombre"], Actividad, Convert.ToDecimal(fila["Deuda"]));
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                            cant++;
                        }
                    }
                }
                Prom = TotDeu / cant;

                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void ListarAct(ComboBox cmb, DataGridView dgv)
        {
            try
            {
                 cant = 0;
                TotDeu = 0;
                String Barrio = "";
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                dgv.Rows.Clear();
                if (DS.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows) 
                    {
                        if (Convert.ToInt32(fila["idActividad"]) == cmb.SelectedIndex + 1)
                        {
                            Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                            dgv.Rows.Add(fila["IdSocio"], fila["Nombre"], Barrio, fila["Deuda"]);

                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                            cant++;
                        }
                    }
                }
                Prom = TotDeu / cant;
                conexion.Close();
                //
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void ListarBar(ComboBox cmb, DataGridView dgv) 
        {
            try
            {
                cant = 0;
                TotDeu = 0;
                String Actividad = "";

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                dgv.Rows.Clear();
                if (DS.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(fila["idBarrio"]) == cmb.SelectedIndex + 1) 
                        {
                            Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                            dgv.Rows.Add(fila["IdSocio"], fila["Nombre"], Actividad, fila["Deuda"]);
                            cant++;
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                        }
                    }
                }
                Prom = TotDeu / cant;
                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void OrdenarIdM ()
        {
            try
            {
                Int32 aux;
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                if (DS.Tables[0].Rows.Count > 0 && DS.Tables[0].Columns.Count > 0) 
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        foreach (DataColumn columna in DS.Tables[Tabla].Columns)
                        {
                            if (Convert.ToInt32(fila["idBarrio"]) == Convert.ToInt32(fila["idBarrio"]))
                            {
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void OrdenarIdm() { }

        public void OrdenarB() { }

        public void OrdenarA() { }

        public void Exportar(String NomRep)
        {
            try
            {
                String Barrio = "";
                String Actividad = "";
                TotDeu = 0;
                cant = 0;
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                StreamWriter AD = new StreamWriter(NomRep, false, Encoding.UTF8);
                AD.WriteLine("Listado de Socios\n");
                AD.WriteLine("IdSocio, Nombre, Direccion, Barrio, Actividad, Deuda\n");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                        Actividad = a.Actividad(Convert.ToInt32(fila["idBarrio"]));

                        AD.Write(Convert.ToInt32(fila["IdSocio"]));
                        AD.Write(',');
                        AD.Write(Convert.ToString(fila["Nombre"]));
                        AD.Write(',');
                        AD.Write(Convert.ToString(fila["Direccion"]));
                        AD.Write(',');
                        AD.Write(Barrio);
                        AD.Write(',');
                        AD.Write(Actividad);
                        AD.Write(',');
                        AD.WriteLine(Convert.ToDecimal(fila["Deuda"]));
                        TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                        cant++;
                    }
                    Prom = TotDeu / cant;
                    AD.Write("Cantidad de Socios:,,");
                    AD.WriteLine(cant);
                    AD.Write("Deuda Total:,,");
                    AD.WriteLine(TotDeu);
                    AD.Write("Promedio de Deuda:,,");
                    AD.Write(Prom);
                }
                conexion.Close();
                AD.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void ExportarDeudores(String NomRep) 
        {
            try
            {
                String Barrio;
                String Actividad;
                TotDeu = 0;
                cant = 0;

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                StreamWriter AD = new StreamWriter(NomRep, false, Encoding.UTF8);
                AD.WriteLine("Listado de Socios Deudores\n");
                AD.WriteLine("IdSocio, Nombre, Direccion, Barrio, Actividad, Deuda\n");

                if (DS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows) 
                    {
                        if (Convert.ToDecimal(fila["Deuda"]) > 0)
                        {
                            Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                            Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                            AD.Write(Convert.ToInt32(fila["IdSocio"]));
                            AD.Write(',');
                            AD.Write(Convert.ToString(fila["Nombre"]));
                            AD.Write(',');
                            AD.Write(Convert.ToString(fila["Direccion"]));
                            AD.Write(',');
                            AD.Write(Barrio);
                            AD.Write(',');
                            AD.Write(Actividad);
                            AD.Write(',');
                            AD.WriteLine(Convert.ToDecimal(fila["Deuda"]));
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                            cant++;
                        }
                    }
                    Prom = TotDeu / cant;
                    AD.Write("Cantidad de Socios Deudores:,,");
                    AD.WriteLine(cant);
                    AD.Write("Total de Deuda:,,");
                    AD.WriteLine(TotDeu);
                    AD.Write("Promedio de Deuda:,,");
                    AD.WriteLine(Prom);
                }
                AD.Close();
                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ExportarActividad(String NomRep) 
        {
            try
            {
                String Barrio = "";
                TotDeu = 0;
                cant = 0;

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                StreamWriter AD = new StreamWriter(NomRep, false, Encoding.UTF8);
                AD.WriteLine("Reporte de Socios por Actividad\n");
                AD.WriteLine("IdSocio, Nombre, Direccion, Barrio, Deuda\n");
                if (DS.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows) 
                    {
                        if (Convert.ToInt32(fila["idActividad"]) == IdActividad) 
                        {
                            Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                            AD.Write(Convert.ToInt32(fila["IdSocio"]));
                            AD.Write(',');
                            AD.Write(Convert.ToString(fila["Nombre"]));
                            AD.Write(',');
                            AD.Write(Convert.ToString(fila["Direccion"]));
                            AD.Write(',');
                            AD.Write(Barrio);
                            AD.Write(',');
                            AD.WriteLine(Convert.ToDecimal(fila["Deuda"]));
                            cant++;
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                        }
                    }
                    Prom = TotDeu/cant;

                    AD.Write("Cantidad de Socios en esta Actividad:,,");
                    AD.WriteLine(cant);
                    AD.Write("Total de Deuda en esta Actividad:,,");
                    AD.WriteLine(TotDeu);
                    AD.Write("Promedio de Deuda en esta Actividad:,,");
                    AD.WriteLine(Prom);
                }
                AD.Close();
                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void ExportarBarrio(String NomRep) 
        {
            try
            {
                String Actividad = "";
                TotDeu = 0;
                cant = 0;

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, Tabla);

                StreamWriter AD = new StreamWriter(NomRep, false, Encoding.UTF8);
                AD.WriteLine("Listado de Clientes por Barrio\n");
                AD.WriteLine("IdSocio, Nombre, Direccion, Actividad, Deuda\n");

                if (DS.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow fila in DS.Tables[Tabla].Rows)
                    {
                        if (Convert.ToInt32(fila["idBarrio"]) == IdBarrio)
                        {
                            Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                            AD.Write(Convert.ToInt32(fila["IdSocio"]));
                            AD.Write(',');
                            AD.Write(Convert.ToString(fila["Nombre"]));
                            AD.Write(',');
                            AD.Write(Convert.ToString(fila["Direccion"]));
                            AD.Write(',');
                            AD.Write(Actividad);
                            AD.Write(',');
                            AD.WriteLine(Convert.ToDecimal(fila["Deuda"]));
                            cant++;
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                        }
                    }
                    Prom = TotDeu /cant;

                    AD.Write("Cantidad de Socios en este Barrio:,,");
                    AD.WriteLine(cant);
                    AD.Write("Deuda Total en este Barrio:,,");
                    AD.WriteLine(TotDeu);
                    AD.Write("Promedio de Deuda en este Barrio");
                    AD.WriteLine(Prom);
                }
                AD.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void Imprimir(PrintPageEventArgs rep)
        {
            try
            {
                String Actividad = "";
                String Barrio = "";
                cant = 0;
                TotDeu = 0;
                img = Image.FromFile(@"C:\Users\54228\Documents\Analista en Sistemas\Laboratorio de Programación II\Programas 2do Cuatri\FinalGenesisLab2\FinalGenesisLab2\bin\Debug\imagen-bonita-de-flores-para-fondo-de-escritorio.jpg");
                int f = 122;

                Font TypeLetterT = new Font("Calibri", 20);
                Font TypeLetterH = new Font("Calibri", 16);
                Font TypeLetter = new Font("Calibri", 12);
                rep.Graphics.DrawString("Listado de Socios", TypeLetterT, Brushes.Black, 300, 70);
                rep.Graphics.DrawString("Id", TypeLetterH, Brushes.MidnightBlue, 70, 100);
                rep.Graphics.DrawString("Nombre", TypeLetterH, Brushes.MidnightBlue, 110, 100);
                rep.Graphics.DrawString("Direccion", TypeLetterH, Brushes.MidnightBlue, 260, 100);
                rep.Graphics.DrawString("Barrio", TypeLetterH, Brushes.MidnightBlue, 408, 100);
                rep.Graphics.DrawString("Actividad", TypeLetterH, Brushes.MidnightBlue, 556, 100);
                rep.Graphics.DrawString("Deuda", TypeLetterH, Brushes.MidnightBlue, 704, 100);

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
                        Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                        Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                        rep.Graphics.DrawString((fila["IdSocio"]).ToString(), TypeLetter, Brushes.Black, 70, f);
                        rep.Graphics.DrawString((fila["Nombre"]).ToString(), TypeLetter, Brushes.Black, 110, f);
                        rep.Graphics.DrawString(fila["Direccion"].ToString(), TypeLetter, Brushes.Black, 260, f);
                        rep.Graphics.DrawString(Barrio, TypeLetter, Brushes.Black, 408, f);
                        rep.Graphics.DrawString(Actividad, TypeLetter, Brushes.Black, 556, f);
                        rep.Graphics.DrawString(Convert.ToString(fila["Deuda"]), TypeLetter, Brushes.Black, 704, f);
                        f = f + 18;
                        cant++;
                        TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                    }
                }
                Prom = TotDeu / cant;
                rep.Graphics.DrawString("Cantidad de Socios: " + cant.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 36);
                rep.Graphics.DrawString("Total de Deuda: " + TotDeu.ToString(), TypeLetter, Brushes.Maroon, 70, f + 54);
                rep.Graphics.DrawString("Promedio de Deuda: " + Prom.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 72);
                
                rep.Graphics.DrawImage(img, 70, f + 90, 700, 300);
                rep.Graphics.Dispose();
                conexion.Close();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ImprimirDeu(PrintPageEventArgs rep) 
        {
            try
            {
                String Actividad = "";
                String Barrio = "";
                img = Image.FromFile(@"C:\Users\54228\Documents\Analista en Sistemas\Laboratorio de Programación II\Programas 2do Cuatri\FinalGenesisLab2\FinalGenesisLab2\bin\Debug\imagen-bonita-de-flores-para-fondo-de-escritorio.jpg");
                cant = 0;
                TotDeu = 0;
                Int32 f = 122;

                Font TypeLetterT = new Font("Calibri", 20);
                Font TypeLetterH = new Font("Calibri", 16);
                Font TypeLetter = new Font("Calibri", 12);
                rep.Graphics.DrawString("Listado de Socios Deudores", TypeLetterT, Brushes.Black, 250, 70);
                rep.Graphics.DrawString("Id", TypeLetterH, Brushes.MidnightBlue, 70, 100);
                rep.Graphics.DrawString("Nombre", TypeLetterH, Brushes.MidnightBlue, 110, 100);
                rep.Graphics.DrawString("Direccion", TypeLetterH, Brushes.MidnightBlue, 260, 100);
                rep.Graphics.DrawString("Barrio", TypeLetter, Brushes.MidnightBlue, 408, 100);
                rep.Graphics.DrawString("Actividad", TypeLetterH, Brushes.MidnightBlue, 556, 100);
                rep.Graphics.DrawString("Deuda", TypeLetterH, Brushes.MidnightBlue, 704, 100);

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
                        if (Convert.ToDecimal(fila["Deuda"]) > 0)
                        {
                            Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                            Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                            rep.Graphics.DrawString(fila["IdSocio"].ToString(), TypeLetter, Brushes.Black, 70, f);
                            rep.Graphics.DrawString(fila["Nombre"].ToString(), TypeLetter, Brushes.Black, 110, f);
                            rep.Graphics.DrawString(fila["Direccion"].ToString(), TypeLetter, Brushes.Black, 260, f);
                            rep.Graphics.DrawString(Barrio, TypeLetter, Brushes.Black, 408, f);
                            rep.Graphics.DrawString(Actividad, TypeLetter, Brushes.Black, 556, f);
                            rep.Graphics.DrawString(fila["Deuda"].ToString(), TypeLetter, Brushes.Black, 704, f);
                            f = f + 18;
                            cant++;
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                        }
                    }
                }
                Prom = TotDeu / cant;
                rep.Graphics.DrawString("Cantidad de Socios Deudores: " + cant.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 36);
                rep.Graphics.DrawString("Total de Deuda: " + TotDeu.ToString(), TypeLetter, Brushes.Maroon, 70, f + 54);
                rep.Graphics.DrawString("Promedio de Deuda: " + Prom.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 72);

                rep.Graphics.DrawImage(img, 70, f + 90, 700, 300);
                rep.Graphics.Dispose();

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ImprimirAct(PrintPageEventArgs rep, ComboBox cmb)
        {
            try
            {
                String Actividad = a.Actividad(cmb.SelectedIndex + 1);
                String Barrio = "";
                img = Image.FromFile(@"C:\Users\54228\Documents\Analista en Sistemas\Laboratorio de Programación II\Programas 2do Cuatri\FinalGenesisLab2\FinalGenesisLab2\bin\Debug\imagen-bonita-de-flores-para-fondo-de-escritorio.jpg");
                cant = 0;
                TotDeu = 0;
                Int32 f = 122;

                Font TypeLetterT = new Font("Calibri", 20);
                Font TypeLetterH = new Font("Calibri", 16);
                Font TypeLetter = new Font("Calibri", 12);

                rep.Graphics.DrawString("Listado de Socios de " + Actividad, TypeLetterT, Brushes.Black, 250, 70);
                rep.Graphics.DrawString("Id", TypeLetterH, Brushes.MidnightBlue, 70, 100);
                rep.Graphics.DrawString("Nombre", TypeLetterH, Brushes.MidnightBlue, 110, 100);
                rep.Graphics.DrawString("Barrio", TypeLetterH, Brushes.MidnightBlue, 260, 100);
                rep.Graphics.DrawString("Deuda", TypeLetterH, Brushes.MidnightBlue, 408, 100);

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
                        if (Convert.ToInt32(fila["idActividad"]) == Convert.ToInt32(cmb.SelectedValue))   
                        {
                            Barrio = b.Barrio(Convert.ToInt32(fila["idBarrio"]));
                            rep.Graphics.DrawString(fila["IdSocio"].ToString(), TypeLetter, Brushes.Black, 70, f);
                            rep.Graphics.DrawString(fila["Nombre"].ToString(), TypeLetter, Brushes.Black, 110, f);
                            rep.Graphics.DrawString(Barrio, TypeLetter, Brushes.Black, 260, f);
                            rep.Graphics.DrawString(fila["Deuda"].ToString(), TypeLetter, Brushes.Black, 408, f);

                            cant++;
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);
                            f = f + 18;
                        }
                    }
                }
                Prom = TotDeu / cant;
                rep.Graphics.DrawString("Cantidad de Socios en " + Actividad + ": " + cant.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 36);
                rep.Graphics.DrawString("Total de Deuda en " + Actividad + ": " + TotDeu.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 54);
                rep.Graphics.DrawString("Promedio de Deuda en " + Actividad + ": " + Prom.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 72);

                rep.Graphics.DrawImage(img, 70, f + 90, 700, 300);
                rep.Graphics.Dispose();

                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        public void ImprimirBar(PrintPageEventArgs rep, ComboBox cmb)
        {
            try
            {
                String Barrio = b.Barrio(cmb.SelectedIndex + 1);
                String Actividad = "";
                img = Image.FromFile(@"C:\Users\54228\Documents\Analista en Sistemas\Laboratorio de Programación II\Programas 2do Cuatri\FinalGenesisLab2\FinalGenesisLab2\bin\Debug\imagen-bonita-de-flores-para-fondo-de-escritorio.jpg");
                cant = 0;
                TotDeu = 0;
                Int32 f = 122;

                Font TypeLetterT = new Font("Calibri", 20);
                Font TypeLetterH = new Font("Calibri", 16);
                Font TypeLetter = new Font("Calibri", 12);

                rep.Graphics.DrawString("Listado de Socios del Barrio " + Barrio, TypeLetterT, Brushes.Black, 250, 70);
                rep.Graphics.DrawString("Id", TypeLetterH, Brushes.MidnightBlue, 70, 100);
                rep.Graphics.DrawString("Nombre", TypeLetterH, Brushes.MidnightBlue, 110, 100);
                rep.Graphics.DrawString("Actividad", TypeLetterH, Brushes.MidnightBlue, 260, 100);
                rep.Graphics.DrawString("Deuda", TypeLetterH, Brushes.MidnightBlue, 408, 100);

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
                        if (Convert.ToInt32(fila["idBarrio"]) == Convert.ToInt32(cmb.SelectedValue)) 
                        {
                            Actividad = a.Actividad(Convert.ToInt32(fila["idActividad"]));
                            rep.Graphics.DrawString(fila["IdSocio"].ToString(), TypeLetter, Brushes.Black, 70, f);
                            rep.Graphics.DrawString(fila["Nombre"].ToString(), TypeLetter, Brushes.Black, 110, f);
                            rep.Graphics.DrawString(Actividad, TypeLetter, Brushes.Black, 260, f);
                            rep.Graphics.DrawString(fila["Deuda"].ToString(), TypeLetter, Brushes.Black, 408, f);

                            f = f + 18;
                            cant++;
                            TotDeu = TotDeu + Convert.ToDecimal(fila["Deuda"]);

                        }
                    }
                }
                Prom = TotDeu / cant;
                rep.Graphics.DrawString("Cantidad de Socios en el Barrio " + Barrio + ": " + cant.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 36);
                rep.Graphics.DrawString("Deuda total en el Barrio " + Barrio + ": " + TotDeu.ToString(), TypeLetter, Brushes.Maroon, 70, f + 54);
                rep.Graphics.DrawString("Promedio de Deuda en el Barrio " + Barrio + ": " + Prom.ToString(), TypeLetter, Brushes.MidnightBlue, 70, f + 72);

                rep.Graphics.DrawImage(img, 70, f + 90, 700, 300);
                rep.Graphics.Dispose();

                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }
    
    }
}
