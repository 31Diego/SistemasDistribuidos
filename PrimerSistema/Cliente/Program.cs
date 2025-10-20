using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        string ipServidor = "127.0.0.1";
        int puerto = 5000;

        TcpClient cliente = new TcpClient();
        cliente.Connect(ipServidor, puerto);

        NetworkStream stream = cliente.GetStream();

        // Paso 1: Recibir mensaje del servidor
        byte[] bufferEntrada = new byte[1024];
        int bytesLeidos = stream.Read(bufferEntrada, 0, bufferEntrada.Length);
        string mensajeRecibido = Encoding.UTF8.GetString(bufferEntrada, 0, bytesLeidos);
        Console.WriteLine("Servidor dice: " + mensajeRecibido);

        // Paso 2: Leer texto del usuario y enviarlo
        Console.Write("Tu respuesta: ");
        string respuesta = Console.ReadLine();
        byte[] bufferSalida = Encoding.UTF8.GetBytes(respuesta);
        stream.Write(bufferSalida, 0, bufferSalida.Length);

        stream.Close();
        cliente.Close();
    }
}

