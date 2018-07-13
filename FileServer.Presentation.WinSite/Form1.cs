using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FileServer.Common.Model;
using FileServer.Infrastructure.Repository_DAO_;
using FileServer.Infrstructure.Repository_DAO_;
using log4net;
using System.Diagnostics;
using System.Resources;
using System.Configuration;

namespace FileServer.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string resxFile = ConfigurationManager.AppSettings["resx"];
        public Form1()
        {
            InitializeComponent();
        }

        public void btnreg_Click(object sender, EventArgs e)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                try
                {
                    int p = 0;
                    var num = 5 / p;
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger("EmailLogger").Error(ex);
                }
                log.Debug(string.Format(@"Datos introducidos del alumno --> ID = {0} | Nombre = {1} | Apellidos = {2} | DNI = {3}",
                          txtid.Text, txtnombre.Text, txtapellidos.Text, txtdni.Text));
                AlumnoRepository AlumnoRepositorio = new AlumnoRepository();
                if (!(int.TryParse(txtid.Text, out int id)))
                {
                    MessageBox.Show(id + "\t--> No es un tipo de dato correcto");
                }
                else
                {
                    Alumno alum = new Alumno(Convert.ToInt32(txtid.Text), txtnombre.Text, txtapellidos.Text,
                    txtdni.Text);
                    var alumnoCreado = AlumnoRepositorio.Add(alum, FileManager.FilePath(comboBox1.SelectedIndex, comboBox2.SelectedIndex));
                    //pendiente de implementar para que SOLO salga en caso de registrarlo correctamente, de momento se muestra siempre
                    FileManager.Validation(alum, alumnoCreado);

                }
            }
            foreach (TextBox tb in this.Controls.OfType<TextBox>().ToArray())
                tb.Clear();

            timer1.Tick += new EventHandler(MyTimer_Tick);
            timer1.Start();
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            txtmensaje.Hide();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                string cmdText = @"C:\Users\G1\source\repos\FileServer\ScripVariableEntorno.ps1";
                Process.Start(@"C:\windows\system32\windowspowershell\v1.0\powershell.exe ", cmdText);
                comboBox1.Items.Add(resxSet.GetString("CBOX_APPCONFIG"));
                comboBox1.Items.Add(resxSet.GetString("CBOX_VAR_ENT"));
                comboBox2.Items.Add(resxSet.GetString("CBOX_JSON"));
                comboBox2.Items.Add(resxSet.GetString("CBOX_TXT"));
                comboBox2.Items.Add(resxSet.GetString("CBOX_XML"));
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }
    }
}
