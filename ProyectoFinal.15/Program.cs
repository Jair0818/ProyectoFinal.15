using System;
public class Usuario
{
    public int Expediente { get; set; }
    public string Nombre { get; set; }
    public string Carrera { get; set; }
    public string Contraseña { get; set;}
    public Usuario(int expediente,  string nombre, string carrera, string contraseña)
    {
        Expediente = expediente;
        Nombre = nombre;
        Carrera = carrera;
        Contraseña = contraseña;
    }
}
public class Libro
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Genero { get; set;}
    public string Editorial { get; set; }
    public string Idioma { get; set; }

    public Libro(int id, string name, string title,string Title,string Genero,string Editorial){
        Id = id;
        Name = name;
        Title = title;
    }

}
public class ProyectoFinal
{
    public static void Main(string[] args)
    {
        string pathUusarios = "Uusarios.txt";
        string pathLibros = "Libros.txt";
        VerificaDoc(pathUusarios);
        VerificaDoc(pathLibros);
        //LogIn(pathUusarios,pathLibros)
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
}