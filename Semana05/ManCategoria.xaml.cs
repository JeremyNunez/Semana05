using System;
using System.Windows;
using System.Collections.Generic;
using Business;
using Entity;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }
        public ManCategoria(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    lblID.Content = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
        }
        private void BntGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria Bcategoria = null;
            bool result = true;
            try
            {
                Bcategoria = new BCategoria();
                if (ID > 0)
                    result = Bcategoria.Actualizar(new Categoria { IdCategoria = ID, NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                else
                    result = Bcategoria.Insertar(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                if (!result)
                    MessageBox.Show("Comuniquese con el Administrador");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comuniquese con el Administrador");
            }
            finally
            {
                Bcategoria = null;
            }
        }

        private void BntCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
