using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data;
using System.IO;

namespace intento_proyecto_c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        class Conexion
        {
            SqlConnection conection;
            SqlCommand comando;
            SqlDataReader reader;
            SqlDataAdapter adaptador;
            DataTable table;

            public Conexion()
            {
                try
                {
                    conection = new SqlConnection("Data Source=.;Initial Catalog=Mc;Integrated Security=True");
                    conection.Open();
                    MessageBox.Show("Se ha conectado con el servidor");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void insertar(dynamic tipo, dynamic sede, string fecha, dynamic cliente, dynamic nit, dynamic ninos, dynamic adultos, dynamic pinata, dynamic payaso, dynamic pastel, int total)
            {
                try
                {
                    comando = new SqlCommand("exec sp_insertar_evento '" + tipo + "'," + "'" +sede+ "'," + "'"+ fecha + "'," + "'" + cliente + "'," + "'" + nit + "'," + "'" + ninos + "'," + "'" + adultos + "'," + "'" + pinata + "'," + "'" + payaso + "'," + "'" + pastel + "'," + total + ";",conection);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Evento reservado satisfactoriamente :)");
                }
                catch (Exception ex)
                {
                   MessageBox.Show("#1"+ex.Message);
                }
            }

            public void facturas(DataGridView view)
            {
                try
                {
                    adaptador = new SqlDataAdapter("exec sp_ver_facturas",conection);
                    table = new DataTable();
                    adaptador.Fill(table);
                    view.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void facturas2(DataGridView view, string fecha)
            {
                try
                {
                    adaptador = new SqlDataAdapter("exec sp_ver_factura_de" + "'" + fecha + "';", conection);
                    table = new DataTable();
                    adaptador.Fill(table);
                    view.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void eve(DataGridView view)
            {
                try
                {

                    adaptador = new SqlDataAdapter("exec sp_ver_eventos", conection);
                    table = new DataTable();
                    adaptador.Fill(table);
                    view.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void eve2(DataGridView view, string fecha)
            {
                try
                {
                    adaptador = new SqlDataAdapter("exec sp_ver_de" + "'" + fecha+"';", conection);
                    table = new DataTable();
                    adaptador.Fill(table);
                    view.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }


        class Miclase
        {
            public bool iniciar(dynamic text, dynamic pss)
            {
                try
                {
                    dynamic tt = text;
                    dynamic archivo = File.OpenRead(text);
                    dynamic st = new StreamReader(archivo);
                    string linea = st.ReadLine();
                    if (linea == pss)
                    {
                        MessageBox.Show("Bienvenido: " + text);
                        archivo.Close();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }

            public bool inicioad(dynamic text, dynamic pss)
            {
                try
                {
                    dynamic archivo = File.OpenRead(text);
                    dynamic st = new StreamReader(archivo);
                    string linea = st.ReadLine();
                    if (linea == pss & text == "Administrador")
                    {
                        MessageBox.Show("Bienvenido Administrador");
                        archivo.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

            public void registrar(dynamic text, dynamic pss, dynamic pss2)
            {
                if (pss != "" & pss2 != "")
                {
                    try
                    {
                        if (pss == pss2)
                        {
                            string usuario = text;
                            File.WriteAllText(usuario, pss2);
                            MessageBox.Show("Usuario registrado con exito");
                        }
                        else
                        {
                            MessageBox.Show("La contraseña no coincide");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios");
                }
            }

        }

        #region instancia
        Miclase Meclase = new Miclase();
        Conexion con = new Conexion();
        #endregion instancia

        #region variables

        dynamic s;
        dynamic m;
        dynamic d;
        dynamic tipo;
        dynamic sede;
        dynamic ni;
        dynamic ad;
        dynamic pi;
        dynamic pi2;
        dynamic pas;
        dynamic pas2;
        dynamic payaso;
        dynamic payaso2;
        dynamic usuario;
        dynamic contra;
        dynamic contra2;
        string menu1;
        string menu2;
        int totalmenus = 0;
        int total2 = 0;
        string fecha;

        #endregion variables


   
        public void combosdias(bool t)
        {
            combodia.Items.Clear();
            if (t)
            {
                combodia.Items.Add("01");
                combodia.Items.Add("02");
                combodia.Items.Add("03");
                combodia.Items.Add("04");
                combodia.Items.Add("05");
                combodia.Items.Add("06");
                combodia.Items.Add("07");
                combodia.Items.Add("08");
                combodia.Items.Add("09");
                combodia.Items.Add("10");
                combodia.Items.Add("11");
                combodia.Items.Add("12");
                combodia.Items.Add("13");
                combodia.Items.Add("14");
                combodia.Items.Add("15");
                combodia.Items.Add("16");
                combodia.Items.Add("17");
                combodia.Items.Add("18");
                combodia.Items.Add("19");
                combodia.Items.Add("20");
                combodia.Items.Add("21");
                combodia.Items.Add("22");
                combodia.Items.Add("23");
                combodia.Items.Add("24");
                combodia.Items.Add("25");
                combodia.Items.Add("26");
                combodia.Items.Add("27");
                combodia.Items.Add("28");
                combodia.Items.Add("29");
            }
            else
            {
                combodia.Items.Add("01");
                combodia.Items.Add("02");
                combodia.Items.Add("03");
                combodia.Items.Add("04");
                combodia.Items.Add("05");
                combodia.Items.Add("06");
                combodia.Items.Add("07");
                combodia.Items.Add("08");
                combodia.Items.Add("09");
                combodia.Items.Add("10");
                combodia.Items.Add("11");
                combodia.Items.Add("12");
                combodia.Items.Add("13");
                combodia.Items.Add("14");
                combodia.Items.Add("15");
                combodia.Items.Add("16");
                combodia.Items.Add("17");
                combodia.Items.Add("18");
                combodia.Items.Add("19");
                combodia.Items.Add("20");
                combodia.Items.Add("21");
                combodia.Items.Add("22");
                combodia.Items.Add("23");
                combodia.Items.Add("24");
                combodia.Items.Add("25");
                combodia.Items.Add("26");
                combodia.Items.Add("27");
                combodia.Items.Add("28");
                combodia.Items.Add("29");
                combodia.Items.Add("30");
                combodia.Items.Add("31");
            }
        }

        public void combos()
        {
            combotipo.Items.Add("Quince Años");
            combotipo.Items.Add("Conferencia");
            combotipo.Items.Add("Graduacion");
            combotipo.Items.Add("Convivio");
            combotipo.Items.Add("Cumpleaños");

            combosede.Items.Add("Zona 1");
            combosede.Items.Add("Zona 4");
            combosede.Items.Add("Zona 5");
            combosede.Items.Add("Zona 6");
            combosede.Items.Add("Zona 9");
            combosede.Items.Add("Zona 10");
            combosede.Items.Add("Zona 13");
            combosede.Items.Add("Zona 15");

            combomes.Items.Add("01");
            combomes.Items.Add("02");
            combomes.Items.Add("03");
            combomes.Items.Add("04");
            combomes.Items.Add("05");
            combomes.Items.Add("06");
            combomes.Items.Add("07");
            combomes.Items.Add("08");
            combomes.Items.Add("09");
            combomes.Items.Add("10");
            combomes.Items.Add("12");

            comboni.Items.Add(0);
            comboni.Items.Add(10);
            comboni.Items.Add(15);
            comboni.Items.Add(20);
            comboni.Items.Add(25);

            comboa.Items.Add(0);
            comboa.Items.Add(10);
            comboa.Items.Add(15);
            comboa.Items.Add(20);
            comboa.Items.Add(25);

            combopiñata.Items.Add("No");
            combopiñata.Items.Add("Toy Story");
            combopiñata.Items.Add("Cars");
            combopiñata.Items.Add("Winnie Pooh");
            combopiñata.Items.Add("Frozen");
            combopiñata.Items.Add("Violeta");
            combopiñata.Items.Add("Minions");
            combopiñata.Items.Add("Rosita Fresita");
            combopiñata.Items.Add("Backyardigans");


            combopastel.Items.Add("No");
            combopastel.Items.Add("Vainilla");
            combopastel.Items.Add("Chocolate");
            combopastel.Items.Add("Fresas con crema");
            combopastel.Items.Add("Zanahoria");
            combopastel.Items.Add("Cafe y Chocolate");
        }

        public void vari(string d)
        {
            label10.Text += "/" + d;
            combodia.Enabled = false;
        }

        public void vari2(string m)
        {
            label10.Text = "2017/" + m;
            combomes.Enabled = false;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //prueba de conexion momentanea
            //con = new Conexion();
            this.Width = 250;
            this.Height = 160;
            this.CenterToScreen();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            btagregar.Enabled = false;
            checkad.Checked = false;
            checkni.Checked = false;
            groupfactura.Visible = false;
            groupadmin.Visible = false;
            groupregistrar.Visible = false;
            groupsesion.Visible = true;
            groupfactura.Visible = false;
            combos();
            combosdias(false);
            combodia.Enabled = false;
        }

        private void combomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            combodia.Enabled = true;
            s = combomes.SelectedIndex;
            if (s == 1)
            {
                combosdias(true);
            }
            else
            {
                combosdias(false);
            }
            m = combomes.SelectedItem.ToString();
            vari2(m);
        }

        private void combodia_SelectedIndexChanged(object sender, EventArgs e)
        {
             d = combodia.SelectedItem.ToString();
            vari(d);
        }

        private void btcambiarfecha_Click(object sender, EventArgs e)
        {
            label10.Text = "Fecha";
            combodia.Enabled = false;
            combomes.Enabled = true;
            combosdias(false);
        }

        private void btagregar_Click(object sender, EventArgs e)
        {

            if (pi != "No")
            {
                pi2 = 300;
            }
            if (pas != "No")
            {
                pas2 = 250;
            }

            fecha = label10.Text;

            try
            {
                if (totalmenus == 0 & txtcliente.Text == "" & txtnit.Text == "" & fecha == "" & ni == null & ad == null & pi == "" & pas == "" & tipo == "" & sede == "")
                {
                    MessageBox.Show("Llena los campos, por favor :)");
                }
                else
                {
                    try
                    {
                        total2 = totalmenus + pi2 + pas2 + payaso;
                        con.insertar(tipo, sede, fecha.ToString(), txtcliente.Text, txtnit.Text, menu2, menu1, pi, payaso2, pas, total2);
                        label10.Text = "";
                       
                        txtcliente.Clear();
                        txtnit.Clear();
                        
                        
                        totalmenus = 0;
                        total2 = 0;
                        checkad.Checked = false;
                        checkni.Checked = false;
                        rdsi.Checked = false;
                        rdno.Checked = false;
                        combodia.Enabled = false;
                        groupfactura.Visible = false;
                        groupsesion.Visible = true;
                        btagregar.Enabled = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("#2" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("#3"+ ex.Message);
            }

           
            
        }

        private void btiniciar_Click(object sender, EventArgs e)
        {

             usuario = txtusu1.Text;
             contra = txtpss1.Text;
            if (usuario == "Administrador" & Meclase.inicioad(usuario, contra) == true)
            {
                groupsesion.Visible = false;
                groupadmin.Visible = true;
            }
            else if (Meclase.iniciar(usuario, contra))
            {
                groupsesion.Visible = false;
                groupfactura.Visible = true;
            }
            txtusu1.Clear();
            txtpss1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             usuario = txtusu2.Text;
             contra = txtpss2.Text;
             contra2 = txtpss3.Text;
            Meclase.registrar(usuario, contra, contra2);
            groupregistrar.Visible = false;
            groupadmin.Visible = true;
            txtusu2.Clear();
            txtpss2.Clear();
            txtpss3.Clear();
        }

        private void btatras1_Click(object sender, EventArgs e)
        {
            txtusu2.Clear();
            txtpss2.Clear();
            txtpss3.Clear();
            groupregistrar.Visible = false;
            groupadmin.Visible = true;
        }

        private void btreg_Click(object sender, EventArgs e)
        {
            groupadmin.Visible = false;
            groupregistrar.Visible = true;
        }

        private void btcerrar1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            label10.Text = "";
            
            txtcliente.Clear();
            txtnit.Clear();
            
            totalmenus = 0;
            total2 = 0;
            checkad.Checked = false;
            checkni.Checked = false;
            rdsi.Checked = false;
            rdno.Checked = false;
            combodia.Enabled = false;
            groupfactura.Visible = false;
            groupsesion.Visible = true;
        }

        private void btcerrar2_Click(object sender, EventArgs e)
        {
            groupadmin.Visible = false;
            groupsesion.Visible = true;
        }

        private void txtpss1_TextChanged(object sender, EventArgs e)
        {

        }

        private void combotipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo = combotipo.SelectedItem;
        }

        private void combosede_SelectedIndexChanged(object sender, EventArgs e)
        {
            sede = combosede.SelectedItem;
        }

        private void comboni_SelectedIndexChanged(object sender, EventArgs e)
        {
             ni = comboni.SelectedItem;
        }

        private void comboa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ad = comboa.SelectedItem;
        }

        private void combopiñata_SelectedIndexChanged(object sender, EventArgs e)
        {
            pi = combopiñata.SelectedItem;
        }

        private void combopastel_SelectedIndexChanged(object sender, EventArgs e)
        {
             pas = combopastel.SelectedItem;
        }


        #region eventos_keypress
       

        private void txtusu2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtusu1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtpss1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtpss2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtpss3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion eventos_keypress

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdsi.Checked == true)
            {
                payaso = 200;
                payaso2 = "Si";
            }
        }

        private void rdno_CheckedChanged(object sender, EventArgs e)
        {
            if (rdno.Checked == true)
            {
                payaso = 100;
                payaso2 = "No";
            }
        }

        private void checkad_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkad.Checked == true)
            {
                groupBox1.Visible = true;  
            }
            else
            {
                rdbigmac.Checked = false;
                rdtasty.Checked = false;
                rdsandwich.Checked = false;
                groupBox1.Visible = false;              
                label22.Text = "0";
                menu1 = "";

            }
        }

        private void rdbigmac_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbigmac.Checked == true)
            {
                label22.Text = "39";
                menu1 = "Big Mac";
            }
        }

        private void rdsandwich_CheckedChanged(object sender, EventArgs e)
        {
            if (rdsandwich.Checked == true)
            {
                label22.Text = "40";
                menu1 = "Sandwich MacPollo";
            }
        }

        private void rdtasty_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtasty.Checked == true)
            {
                label22.Text = "43";
                menu1 = "Big Tasty Bacon";
            }
        }

        private void checkni_CheckedChanged(object sender, EventArgs e)
        {
            if (checkni.Checked == true)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
                rdni1.Checked = false;
                rdni2.Checked = false;
                label23.Text = "0";
                menu2 = "";
            }
        }

        private void rdni1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdni1.Checked == true)
            {
                label23.Text = "38";
                menu2 = "Cajita Muffin Salchicha";
            }
        }

        private void rdni2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdni2.Checked == true)
            {
                label23.Text = "36";
                menu2 = "Cajita Quesoburguesa";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btagregar.Enabled = true;
            try
            {
                totalmenus = (ad * int.Parse(label22.Text)) + (ni * int.Parse(label23.Text));
                MessageBox.Show("En sus menus hay Q: "+totalmenus.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupmenus.Visible = true;
        }

        private void btver_Click(object sender, EventArgs e)
        {
            try
            {
                con.eve(dataGridView1);
                
            }
            catch (Exception ex)
            {

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.facturas(dataGridView1);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.TextLength <10)
            {
                MessageBox.Show("No hay fecha para capturar");
            }
            else
            {
                try
                {
                    con.facturas2(dataGridView1,textBox2.Text);
                    textBox2.Clear();
                    
                }
                catch (Exception ex)
                {
                    textBox2.Clear();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.TextLength < 10)
            {
                MessageBox.Show("No hay fecha para capturar");
            }
            else
            {
                try
                {
                    con.eve2(dataGridView1, textBox1.Text);
                    textBox1.Clear();

                }
                catch (Exception ex)
                {
                    textBox1.Clear();
                }
            }
        }
    }
}
