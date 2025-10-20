using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        int puerto = 5000;
        TcpListener servidor = new TcpListener(IPAddress.Any, puerto);

        servidor.Start();
        Console.WriteLine($"Servidor escuchando en el puerto {puerto}...");

        while (true)
        {
            TcpClient cliente = servidor.AcceptTcpClient();
            NetworkStream stream = cliente.GetStream();

            // Paso 1: Enviar mensaje al cliente
            string mensajeAlCliente = "Por favor, ingrese un texto:";
            byte[] bufferSalida = Encoding.UTF8.GetBytes(mensajeAlCliente);
            stream.Write(bufferSalida, 0, bufferSalida.Length);
            Console.WriteLine("Mensaje enviado al cliente.");

            // Paso 2: Esperar la respuesta del cliente
            byte[] bufferEntrada = new byte[1024];
            int bytesLeidos = stream.Read(bufferEntrada, 0, bufferEntrada.Length);
            string textoRecibido = Encoding.UTF8.GetString(bufferEntrada, 0, bytesLeidos);

            Console.WriteLine($"Texto recibido del cliente: {textoRecibido}");

            stream.Close();
            cliente.Close();
        }
    }
}

