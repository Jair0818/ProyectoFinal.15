using System;
public class ProyectoFinal
{
    public static void Main(string[] args)
    {
        string pathUusarios = "Uusarios.txt";
        string pathLibros = "Libros.txt";
        VerificaDoc(pathUusarios);
        VerificaDoc(pathLibros);
        LogIn(pathUusarios);
        LogIn(pathLibros);
    }
    public static void VerificaDoc(string path)
    {
        if (File.Exists(path))
        {
            Console.WriteLine("El archivo no existe, creando documentacion necesaria...");
            CrearDoc(path);
            Console.WriteLine("Documentacion creada con éxito");
        }
    }
    public static void CrearDoc(string path)
    {
        using (StreamWriter crear = File.CreateText(path))
        {
            crear.WriteLine("Bienvenido a la Biblioteca LoveBook");
        }
    }
    public static string LecturaDoc(string path)
    {
        using(StreamReader lectura = File.OpenText(path))
        {
            return lectura.ReadToEnd();
        }
    }
    public static  void LogIn(string pathUsuario, string pathLibros)
    {

    }
}