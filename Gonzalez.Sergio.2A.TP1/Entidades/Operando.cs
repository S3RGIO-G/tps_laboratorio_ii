using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {

        private double numero;
        
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        // CONSTRUCTORES: ****************************************************************************************************

        /// <summary>
        /// Llama al constructor parametrizado y setea el valor en 0
        /// </summary>
        public Operando() : this(0) {}

        /// <summary>
        /// Asigna el valor recibido por parametros al atributo de la clase
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Hace referencia a la propiedad de la clase, asignandole el valor que recibe por parametros
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {            
            this.Numero = strNumero;
        }
        // SOBRECARGAS: ****************************************************************************************************

        /// <summary>
        /// Suma los valores de los atributos de los objetos recibidos por parametros y retorna el resultado
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Resta los valores de los atributos de los objetos recibidos por parametros y retorna el resultado
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Multiplica los valores de los atributos de los objetos recibidos por parametros y retorna el resultado
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Divide los valores de los atributos de los objetos recibidos por parametros y retorna el resultado. En caso de que el divisor sea 0 retorna double.MinValue
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado = double.MinValue;
            if(n2.numero != 0 )
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }

        // METODOS: ****************************************************************************************************

        /// <summary>
        /// Valida que el string recibido se pueda parsear a double. Devuelve el resultado del parseo o 0 si no se pudo parsear.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private static double ValidarOperando(string strNumero)
        {
            if (!double.TryParse(strNumero, out double numero))
            {
                numero = 0;
            }
            return numero;
        }

        /// <summary>
        /// Valida que el valor recibido sea un numero binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            bool resultado = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    resultado = false;
                    break;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Covierte el numero Binario recibido a Decimal, llama a Esbinario para validar.
        /// Solo se trabajara con la parte entera y absoluta del binario recibido.
        /// En caso de no poder hacer la conversion se retorna "¡Valor Invalido!"
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDemcimal(string binario)
        {
            string resultado = "¡Valor Invalido!";
            long entero = 0;
            int exponente = 0;

            if (binario.Contains('-'))
            {
                binario = binario.Remove(0, 1);
            }
            if (binario.Contains(','))
            {
                binario = binario.Remove(binario.IndexOf(','));
            }
                
            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i > -1; i--)
                {
                    if (binario[i] == '1')
                    {
                        entero += (long)Math.Pow(2, exponente);
                    }
                    exponente++;
                }
                if(entero > 0)
                {
                    resultado = entero.ToString();
                }                
            }            
            return resultado;
        }

        /// <summary>
        /// Convierte el numero Decimal recibido en un Binario. 
        /// Solo se trabajara con la parte entera y absoluta del binario recibido.
        /// En caso de no poder hacer la conversion se retorna "¡Valor Invalido!"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string binario = string.Empty;
            int resto;
            long entero = (long) Math.Abs(numero);
            while (entero > 0)
            {
                resto = (int) entero % 2;
                entero /= 2;
                binario = resto.ToString() + binario;
            }
            if(binario == string.Empty)
            {
                binario = "¡Valor Invalido!";
            }
            return binario;
        }
        /// <summary>
        /// Parsea el valor recibido y llama a DecimalBinario(double).
        /// En caso de no poder parsear retorna "¡Valor Invalido!"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string binario = "¡Valor Invalido!";

            if(double.TryParse(numero, out double numeroParseado))
            {
                binario = DecimalBinario(numeroParseado);
            }
            return binario;
        }
    }
}
