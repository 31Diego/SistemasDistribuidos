
using System;


namespace holaMundo
{
    class Persona
    {
        private string _nombre;
        private int _edad;


        public Persona(string nombre, int edad)
        {
            _nombre = nombre;
            _edad = edad;
        }


        public void Saludar()
        {
            Console.WriteLine($"Hola, soy {_nombre} y tengo {_edad} años");
        }

    }
}
    
