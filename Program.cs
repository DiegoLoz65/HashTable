using System;

namespace TablaHash_Sondeo_
{
    class Program
    {
        private static Celdas[] tabla;
        private static int cantidad;
        static void Main(string[] args)
        {
            int n=0;
            cantidad=11;
            tabla = new Celdas[cantidad];
            for(n=0; n<cantidad; n++){
                tabla[n] = new Celdas();
            }

            Insertar(23, "JavaScript");
            Insertar(51, "Php");
            Insertar(40, "Nodejs");
            Insertar(62, "Csharp");

            Mostrar();



        }

        
        public static void Mostrar(){
            int n=0;
            for(n=0; n<cantidad; n++){
                Console.WriteLine("{0} [{1}]", n, tabla[n].Llave, tabla[n].Valor);
            }
        }

        public static int HashFunction(int pLlave, int pIntentos){
            int indice=0;
            indice=(pLlave + pIntentos) % cantidad;
            return indice;
        }

        public static void Insertar(int pLlave, string pValor){
            int i =0;
            int indice = 0;
            bool ocupado = false;
            while(ocupado == false){
                indice = HashFunction(pLlave, i);
                if(tabla[indice].MiEstado == estado.vacio){
                    ocupado = true;
                    tabla[indice].Llave =pLlave;
                    tabla[indice].Valor = pValor;
                    tabla[indice].MiEstado = estado.ocupado;
                } else{
                    i++;
                }
            }
        }



    }

    #region Clases Anidadas
    enum estado{
        vacio, ocupado, borrado
    }

    public class Celdas{
        private int llave;
        private string valor;
        private estado miEstado;
        
        public int Llave{
            get => llave; 
            set => llave = value;
        }
        public string Valor{
            get => valor; 
            set => valor = value;
        }
        internal estado MiEstado{
            get=>miEstado;
            set=>miEstado=value;
        }

    }
    #endregion
}
