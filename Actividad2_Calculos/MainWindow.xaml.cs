using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace Actividad2_Calculos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void reiniciarButton_Click(object sender, RoutedEventArgs e)
        {
            resultadoTextBox.Text = "";
            numero1TextBox.Text = "";
            numero2TextBox.Text = "";
            operadorTextBox.Text = "";
        }
        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            int resultado = 0;
            int num1 = int.Parse(numero1TextBox.Text);
            int num2 = int.Parse(numero2TextBox.Text);
            char operador = char.Parse(operadorTextBox.Text);
            try
            {
                switch (operador)
                {
                    case '*':
                        resultado = num1 * num2;
                        break;
                    case '/':
                        resultado = num1 / num2;
                        break;
                    case '+':
                        resultado = num1 + num2;
                        break;
                    case '-':
                        resultado = num1 - num2;
                        break;
                    default:
                        break;
                }
                resultadoTextBox.Text = resultado.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Se ha producido un error: " + ex.Message);
            }
        }
        private void operadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String operador = operadorTextBox.Text;
            String patron = @"([+*\/-])+";
            Regex regex = new Regex(patron);
            Match coincidencia = regex.Match(operador);
            if (coincidencia.Success)
                calcularButton.IsEnabled = true;
            else
                calcularButton.IsEnabled = false;

        }
    }
}
