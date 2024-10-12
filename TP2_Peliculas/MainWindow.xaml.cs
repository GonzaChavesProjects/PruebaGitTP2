using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP2_Peliculas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Instancio una lista de la clase lista_generos
            List<lista_generos> generos = new List<lista_generos>();

            // Agrego los generos a la lista
            generos.Add(new lista_generos { genero = "Comedia" });
            generos.Add(new lista_generos { genero = "Drama" });
            generos.Add(new lista_generos { genero = "Terror" });
            generos.Add(new lista_generos { genero = "Accion" });
            generos.Add(new lista_generos { genero = "Romance" });
            generos.Add(new lista_generos { genero = "Policial" });
            generos.Add(new lista_generos { genero = "Anime" });
            generos.Add(new lista_generos { genero = "Infantil" });

            // Vinculo el combobox con los campos de la lista
            generoPelicula.ItemsSource = generos;

            List<lista_paises> paises = new List<lista_paises>();

            // Agrego paises a la lista 
            paises.Add(new lista_paises { pais = "Alemania" });
            paises.Add(new lista_paises { pais = "Argentina" });
            paises.Add(new lista_paises { pais = "China" });
            paises.Add(new lista_paises { pais = "Corea del Sur" });
            paises.Add(new lista_paises { pais = "España" });
            paises.Add(new lista_paises { pais = "Estados Unidos" });
            paises.Add(new lista_paises { pais = "Francia" });
            paises.Add(new lista_paises { pais = "India" });
            paises.Add(new lista_paises { pais = "Italia" });
            paises.Add(new lista_paises { pais = "Japon" });
            paises.Add(new lista_paises { pais = "Reino Unido" });
            paises.Add(new lista_paises { pais = "Otros" });

            // Vinculo el combobox con los campos de la lista
            paisdefilmacion.ItemsSource = paises;


        }

        // Creo la clase que contendra la informacion de losgeneros
        public class lista_generos
        {
            public string genero { get; set; }

        }

        // Creo la clase que contiene la lista de los paises
        public class lista_paises
        {
            public string pais { get; set; }

        }

       
        // funcion para realizar las validaciones
        public void validar( TextBox textbox , int limite )
        {
            MessageBox.Show($"Excedio los {limite} caracteres", "Mensaje", MessageBoxButton.OK);
            textbox.Text = string.Empty;
        }

        // Evento que maneja la validacion del nombre de la pelicula
        private void nombrePelicula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nombrePelicula.Text.Length > 50)
            {
                validar(nombrePelicula, 50);
            }
        }

        // Evento que maneja la validacion del nombre del director
        private void nombreDirector_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nombreDirector.Text.Length > 30)
            {
                validar( nombreDirector, 30);
            }
        }
        // Evento que maneja la validacion de los dias de filmacion

        private void diasdefilmacion_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Este if verifica si el TextBox no está vacío
            if (!string.IsNullOrEmpty(diasdefilmacion.Text))
            {
                int valor;

                // Dentro del if se intenta convertir el texto a número
                if (int.TryParse(diasdefilmacion.Text, out valor))
                {
                    // En el caso de que la conversion sea exitosa,
                    // Se verifica si está en el rango permitido.
                    if (valor < 1 || valor > 365)
                    {
                        MessageBox.Show("El valor debe estar entre 1 y 365.");
                        diasdefilmacion.Clear(); // Limpia el contenido del TextBox
                    }
                }
                //Este bloque se ejecuta si la conversion falló 
                //es decir el usuario ingresó texto o caracteres no numéricos.
                else
                {
                    MessageBox.Show("Solo se permiten números.");
                    diasdefilmacion.Clear(); // Limpia el contenido del textbox si no es un número
                }
            }
        }

        private void TextBox_Selected(object sender, RoutedEventArgs e)
        {

        }


        private void Duracion_film_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                // Este if verifica si el TextBox no está vacío
                if (!string.IsNullOrEmpty(duracion_film.Text))
                {
                    int valor2;

                    // Dentro del if se intenta convertir el texto a número
                    if (int.TryParse(duracion_film.Text, out valor2))
                    {
                        // En el caso de que la conversión sea exitosa,
                        // Se verifica si está en el rango permitido.
                        if (valor2 < 15 || valor2 > 240)
                        {
                            MessageBox.Show("El valor debe estar entre 15 y 240 minutos");
                            duracion_film.Clear(); // Limpia el contenido del TextBox
                        }
                    }
                    // Este bloque se ejecuta si la conversión falló 
                    // es decir, el usuario ingresó texto o caracteres no numéricos.
                    else
                    {
                        MessageBox.Show("Ingreso no válido.");
                        duracion_film.Clear(); // Limpia el contenido del textbox si no es un número
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void TextBox2_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void fechaEstreno_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fechadeestreno.SelectedDate.HasValue)
            {
                // Mostrar un mensaje de confirmación con la fecha seleccionada
                MessageBox.Show($"Fecha de estreno seleccionada: {fechadeestreno.SelectedDate.Value.ToShortDateString()}", "Fecha de estreno", MessageBoxButton.OK);
            }

        }


        private void añoRealizacion_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(añoRealizacion.Text) < 1900 || Convert.ToInt32(añoRealizacion.Text) > 2024)
            {
                MessageBox.Show("Año ingresado fuera de rango");
                añoRealizacion.Text = string.Empty;
            }
        }
    }
}