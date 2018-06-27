﻿using System;
using System.Linq;
using System.Windows.Forms;
using FileServer.Common.Model;
using FileServer.Infrstructure.Repository_DAO_;

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
            Console.WriteLine(string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}", alum.Id
                , alum.Nombre, alum.Apellidos, alum.DNI));
            AlumnoRepositorio.Registrar(alum);
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
    }
}
