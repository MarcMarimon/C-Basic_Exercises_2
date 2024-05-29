using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }
        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Dia de la semana Laboral o fin de semana");
                Console.WriteLine("2. Contraseña");
                Console.WriteLine("3. Calculadora de dos numeros");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CalcularDiaLaboral();
                        break;
                    case 2:
                        CalcularContraseña();
                        break;
                    case 3:
                        CalcularOperacion();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
        static void CalcularDiaLaboral()
        {
            Console.WriteLine("Introduzca un dia de la semana:");
            string diaSemana = Console.ReadLine();
            bool isLaboral = IsDiaLaboral(diaSemana);

            if (isLaboral)
            {
                Console.WriteLine($"{diaSemana} es un dia laboral");
            }
            else
            {
                Console.WriteLine($"{diaSemana} no es un dia laboral");
            }
        }
        
        static bool IsDiaLaboral(string dia)
        {
            switch (dia.ToLower())
            {
                case "lunes":
                case "martes":
                case "miércoles":
                case "miercoles":
                case "jueves":
                case "viernes":
                    return true;
                case "sábado":
                case "sabado":
                case "domingo":
                    return false;
                default:
                    Console.WriteLine("Día no reconocido. Por favor, introduzca un día válido.");
                    return false;
            }
        }

        static void CalcularContraseña()
        {
            string contraseña = "contraseña";
            bool contraseñaCorrecta = IntentoContraseña(contraseña);

            if (contraseñaCorrecta)
            {
                Console.WriteLine("Enhorabuena, contraseña correcta");
            }
            else
            {
                Console.WriteLine("Has superado el limite de intentos");
            }
        }

        static bool IntentoContraseña(string contraseña)
        {
            for (int intento = 0; intento < 3; intento++)
            {
                Console.WriteLine("Introduzca la contraseña, tiene tres intentos:");
                string input = Console.ReadLine();

                if (input == contraseña)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta, intentos restantes: " + (2 - intento));
                }
            }
            return false;
        }
        static double NumeroValido()
        {
            string entrada = Console.ReadLine();
            if (!double.TryParse(entrada, out double numero))
            {
                throw new FormatException();
            }
            return numero;
        }
        static void CalcularOperacion()
        {
            try
            {
                Console.WriteLine("Introduzca el primer operando:");
                double operando1 = NumeroValido();

                Console.WriteLine("Introduzca el segundo operando:");
                double operando2 = NumeroValido();

                Console.WriteLine("Introduzca el signo aritmético (+, -, *, /, ^, %):");
                char signo = char.Parse(Console.ReadLine());

                double resultado = Operacion(operando1, operando2, signo);
                Console.WriteLine($"El resultado de la operación es: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Introduzca un numero valido en los operandos");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        static double Operacion(double operando1, double operando2, char signo)
        {
            switch (signo)
            {
                case '+':
                    return operando1 + operando2;
                    
                case '-':
                    return operando1 - operando2;
                    
                case '*':
                    return operando1 * operando2;
                    
                case '/':
                    if(operando2 == 0)
                    {
                        throw new ArgumentException("No es posible dividir por 0");
                    }
                    return operando1 / operando2;

                case '^':
                    return Math.Pow(operando1, operando2);

                case '%':
                    if(operando2 == 0)
                    {
                        throw new ArgumentException("El modulo no puede ser 0");
                    }
                    return operando1 % operando2;

                default:
                    throw new ArgumentException("Signo aritmetico no valido");
            }
        }
    }
}
