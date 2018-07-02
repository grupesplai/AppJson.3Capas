using System;
using System.Linq;
using System.Windows.Forms;
using FileServer.Common.Model;
using System.Configuration;
using FileServer.Infrastructure.Repository_DAO_;


namespace FileServer.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btnreg_Click(object sender, EventArgs e)
        {
            Alumno alum = new Alumno();
            AlumnoRepository AlumnoRepositorio = new AlumnoRepository();

            alum.Id = Convert.ToInt32(txtid.Text);
            alum.Nombre = txtnombre.Text;
            alum.Apellidos = txtapellidos.Text;
            alum.DNI = txtdni.Text;
            string path = "";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    path = ConfigurationManager.AppSettings["path"];
                    break;
                case 1:
                    if (Environment.GetEnvironmentVariable("Vueling_JSON") == null)
                        Environment.SetEnvironmentVariable("Vueling_JSON", ConfigurationManager.AppSettings["pathEnVa"]);

                    path = Environment.GetEnvironmentVariable("Vueling_JSON");
                    break;
            }
            Console.WriteLine(string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}", alum.Id
                , alum.Nombre, alum.Apellidos, alum.DNI));
            AlumnoRepositorio.Add(alum, path);
            //pendiente de implementar para que SOLO salga en caso de registrarlo correctamente, de momento se muestra siempre

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
            comboBox1.Items.Add("App.config");
            comboBox1.Items.Add("Variable de entorno");
            comboBox1.SelectedIndex = 0;
        }
    }
}
