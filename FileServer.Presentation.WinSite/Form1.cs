using System;
using System.Linq;
using System.Windows.Forms;
using FileServer.Common.Model;
using FileServer.Infrastructure.Repository_DAO_;
using System.Configuration.Assemblies;
namespace FileServer.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnreg_Click(object sender, EventArgs e)
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
                    //se ha importado system.configuration y se ha referenciado a su respectiva dll...
                    break;
                case 1:
                    break;
            }
            
            Console.WriteLine(string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}", alum.Id
                , alum.Nombre, alum.Apellidos, alum.DNI));
            AlumnoRepositorio.Registrar(alum, path);
            //pendiente de implementar para que SOLO salga en caso de registrarlo correctamente, de momento se muestra siempre
            txtmensaje.Text = "Alumno registrado correctamente.";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("App.config");
            comboBox1.Items.Add("Variable de entorno");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
