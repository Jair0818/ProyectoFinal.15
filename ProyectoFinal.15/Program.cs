/*using System;
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
    public string Author { get; set; }
    public string Title { get; set; }
    public string Genero { get; set;}
    public string Editorial { get; set; }
    public string Idioma { get; set; }

    public Libro(int id, string name, string title,string Title,string Genero,string Editorial){
   
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
}*/
using System;
public class Programa
{
    public static void Main()
    {
        string path = "Usuarios.txt";
        string path2 = "Libros.txt";
        VerificaDoc(path);
        VerificaDoc(path2);
        string cont = LecturaDocs(path);
        string cont1 = LecturaDocs(path2);
        LogIn(path);
    }
    public static void LogIn(string path)
    {
        string[,] datos;
        datos = CrearMatrizUsuario(path);
        string id = EntradaDatos("Ingresa Expediente");
        Console.Clear();
        string psw = EntradaDatos("Ingresa Contraseña");
        Console.Clear();
        int userFlow = EncontrarCasillaMatriz(datos, id);
        if (userFlow >= 0)
        {
            if (datos[userFlow, 3].Trim().Equals(psw))
            {
                Console.WriteLine("Contraseña correcta");
                Console.Clear();
                Ejecucion(path, datos);
            }
            else Console.WriteLine("Credenciales Incorrectas");
        }
        else
        {
            //Crea o dar alta del usuario
            Console.WriteLine("Uusario Inexistente");
            DarAlta(datos);
            EscribirCambiosAlta(path, datos);
        }
    }
    public static void VerificaDoc(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Los archivos no existen,+" +
                "creando Documentacion necesaria...");
            CrearDocs(path);
            Console.WriteLine("Documentacion Creada con exito");
        }
    }
    //no mover
    public static void CrearDocs(string path)
    {
        StreamWriter crear = File.CreateText(path);
        crear.WriteLine("Bienvenido a la Biblioteca LoveBooks");
        crear.Close();
    }
     //no mover
    public static string LecturaDocs(string path)
    {
        string texto;
        StreamReader lectura = File.OpenText(path);
        texto = lectura.ReadToEnd();
        lectura.Close();
        return texto;
    }
    public static void MostrarMenu()
    {
        Console.WriteLine("LoveBooks");
        Console.WriteLine("Ingresa la opción deseada: ");
        Console.WriteLine("1-ALta de Usuarios");
        Console.WriteLine("2-Baja de Usuarios");
        Console.WriteLine("3-Cambio de Contraseña");
        Console.WriteLine("4-Solicitar Prestamos");
        Console.WriteLine("5-Buscar Libro");
        Console.WriteLine("6-Salir");
    }
    public static void MenuLibro()
    {
        Console.WriteLine("1-Buscar libro por ID");
        Console.WriteLine("2-Buscar libro por Autor");
        Console.WriteLine("3-Buscar libro por el Nombre del Libro");
        Console.WriteLine("4-Buscar libro por la Categoria");
        Console.WriteLine("5-Buscar libro por la Editorial");
        Console.WriteLine("6-Buscar libro por el Idioma");
        Console.Clear();
        string lib= EntradaDatos("Ingresa una opcion:");
        switch (lib){
            case"1"://id
            break;
            case"2"://autor
            break;
            case"3"://libro
            break;
            case"4"://categoria
            break;
            case"5"://editorial
            break;
            case"6"://idioma
            break;
        }
    }
    public static void Ejecucion(string path, string[,] datos)
    {
        MostrarMenu();
        string entrada = EntradaDatos("Ingresa tu opcion: ");
        switch (entrada)
        {
            case "1": //Alta
                Console.Clear();
                DarAlta(datos);
                EscribirCambiosAlta(path, datos);
                break;
            case "2": //Baja
                Console.Clear();
                DarBaja(datos);
                EscribirCambios(path, datos);
                break;
            case "4"://contraseña
                Console.Clear();
                string exp = EntradaDatos("Ingresa tu expediente: ");
                break;
            case "5"://prestamos
                Console.Clear();
                exp = EntradaDatos("Ingresa tu expediente: ");
                //CambiarDato(exp, arregloPalabras, path, 4);
                break;
            case "6": //buscar libro
                MenuLibro();
                break;
            case "7"://salir
                break;
        }
    }
    //no mover 
    public static string[,] CrearMatrizUsuario(string path)
    {
        string texto = LecturaDocs(path); //Obteniendo el texto del txt
        string[] filas = texto.Split('\n');
        string[,] matriz = new string[filas.Length, 3];
        for (int i = 0; i < filas.Length; i++)
        {
            string[] datosDeFila = filas[i].Split(',');
            for (int j = 0; j < datosDeFila.Length; j++)
            {
                matriz[i, j] = datosDeFila[j].Trim();
            }
        }
        return matriz;
    }
    public static string[,] CrearMatrizLibro(string path2)
    {
        string texto = LecturaDocs(path2); //Obteniendo el texto del txt
        string[] filas = texto.Split('\n');
        string[,] matriz = new string[filas.Length, 3];
        for (int i = 0; i < filas.Length; i++)
        {
            string[] datosDeFila = filas[i].Split(',');
            for (int j = 0; j < datosDeFila.Length; j++)
            {
                matriz[i, j] = datosDeFila[j].Trim();
            }
        }
        return matriz;
    }
    public static void EscribirCambiosMatriz(string path, string[,] arreglo)
    {
        StreamWriter escritura = File.CreateText(path);
        for (int j = 0; j < arreglo.GetLength(0); j++)
        {
            for (int i = 0; i < arreglo.GetLength(1); i++)
            {
                if (i == arreglo.GetLength(1) - 1)
                {
                    escritura.Write(arreglo[j, i]);
                }
                else
                {
                    escritura.Write(arreglo[j, i]);
                    escritura.Write(','); //va a existir una coma al final
                }

            }
            if (!(j == arreglo.GetLength(0) - 1))
            {
                escritura.WriteLine();
            }
        }

        escritura.Close();
    }
    public static void EscribirCambiosLibros(string path2, string[,] arreglo)
    {
        StreamWriter escritura = File.CreateText(path2);
        for (int j = 0; j < arreglo.GetLength(0); j++)
        {
            for (int i = 0; i < arreglo.GetLength(1); i++)
            {
                if (i == arreglo.GetLength(1) - 1)
                {
                    escritura.Write(arreglo[j, i]);
                }
                else
                {
                    escritura.Write(arreglo[j, i]);
                    escritura.Write(','); //va a existir una coma al final
                }

            }
            if (!(j == arreglo.GetLength(0) - 1))
            {
                escritura.WriteLine();
            }
        }

        escritura.Close();
    }
    public static void DarBaja(string[,] datos)
    {
        String bajaExp = EntradaDatos("Ingresa el expediente a elimianr: ");
        int fila = EncontrarCasillaMatriz(datos, bajaExp);
        if (fila >= 0) //No se encuentra el expediente
        {
            Console.WriteLine($"Dando baja a {bajaExp}");
            for (int i = 0; i < datos.GetLength(1); i++)
            {
                datos[fila, i] = "-1";
            }
        }
        else Console.WriteLine("Expediente no encontrado, imposible eliminar...");
    }
    public static void DarAlta(string[,] datos)
    {
        //Verificar que el expediente no exista en la BD
        String altaExp = EntradaDatos("Ingresa el expediente a agregar: ");
        if (EncontrarCasillaMatriz(datos, altaExp) < 0) //
        {
            string datosUsuario = EntradaDatos("Ingresa tu nombre, carrera y contraseña separado por comas (,): ");
            string[] filaAgregar = datosUsuario.Split(',');
            datos[datos.GetLength(0) - 1, 0] = altaExp;
            for (int i = 1; i < datos.GetLength(1); i++)
            {
                datos[datos.GetLength(0) - 1, i] = filaAgregar[i - 1];
            }
        }
        else
        {
            Console.WriteLine("Expediente repetido, imposible dar de alta");
        }
    }
    public static void DarAltaLibros(string[,] datos)
    {
        //Verificar que el expediente no exista en la BD
        String altaExp = EntradaDatos("Ingresa el expediente a agregar: ");
        if (EncontrarCasillaMatriz(datos, altaExp) < 0) //
        {
            string datosUsuario = EntradaDatos("Ingresa tu nombre, carrera y contraseña separado por comas (,): ");
            string[] filaAgregar = datosUsuario.Split(',');
            datos[datos.GetLength(0) - 1, 0] = altaExp;
            for (int i = 1; i < datos.GetLength(1); i++)
            {
                datos[datos.GetLength(0) - 1, i] = filaAgregar[i - 1];
            }
        }
        else
        {
            Console.WriteLine("Expediente repetido, imposible dar de alta");
        }
    }
    public static void CambiarDatoMatriz(string exp, string[,] arregloPalabras, string path, int x)
    {
        //Buscar al expediente que vamos a modificar
        int filaUsuario = -1;
        filaUsuario = EncontrarCasillaMatriz(arregloPalabras, exp); //va dar un número > 0 si existe le user
        if (filaUsuario >= 0)
        {
            string entrada = EntradaDatos("Ingresa el nuevo valor: ");
            arregloPalabras[filaUsuario, x] = entrada;
            EscribirCambios(path, arregloPalabras);
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }
     public static void CambiarDatoLibros(string exp, string[,] arregloPalabras, string path2, int x)
    {
        //Buscar al expediente que vamos a modificar
        int filaUsuario = -1;
        filaUsuario = EncontrarCasillaMatriz(arregloPalabras, exp); //va dar un número > 0 si existe le user
        if (filaUsuario >= 0)
        {
            string entrada = EntradaDatos("Ingresa el nuevo valor: ");
            arregloPalabras[filaUsuario, x] = entrada;
            EscribirCambios(path2, arregloPalabras);
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }
    public static string EntradaDatos(string texto)
    {
        Console.WriteLine(texto);
        return Console.ReadLine();
    }
    public static string EntradaDatosLibros(string texto)
    {
        Console.WriteLine(texto);
        return Console.ReadLine();
    }
    public static int EncontrarCasillaLibros(string[,] arreglo, string expediente)
    {
        for (int i = 0; i < arreglo.GetLength(0); i++)
        {
            if (arreglo[i, 1].Contains("rafa"))
            {
                return i;
            }
        }
        return -1;
    }
    public static void Filtrado(string[,] datos, string filtro, int x)
    {
        for (int i = 0; i < datos.GetLength(0) - 1; i++)
        {
            if (datos[i, ].ToLower().Contains(filtro.ToLower()))
            {
                for (int j = 0; j < datos.GetLength(1); j++)
                {
                    Console.Write(datos[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
    public static int EncontrarCasillaMatriz(string[,] arreglo, string expediente)
    {
        for (int i = 0; i < arreglo.GetLength(0); i++)
        {
            if (arreglo[i, 0].Trim() == expediente.Trim())
            {
                return i;
            }
        }
        return -1;
    }
    public static void ImprimirMatriz(string[,] arreglo)
    {
        for (int i = 0; i < arreglo.GetLength(0); i++)
        {
            for (int j = 0; j < arreglo.GetLength(1); j++)
            {
                Console.Write(arreglo[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();

        }
    }
    public static void EscribirCambios(string path, string[,] arreglo)
    {
        StreamWriter escritura = File.CreateText(path);
        for (int j = 0; j < arreglo.GetLength(0); j++)
        {
            for (int i = 0; i < arreglo.GetLength(1); i++)
            {
                if (i == arreglo.GetLength(1) - 1)
                {
                    escritura.Write(arreglo[j, i]);
                }
                else
                {
                    escritura.Write(arreglo[j, i]);
                    escritura.Write(','); //Va a existir una coma al final
                }
            }
            if (!(j == arreglo.GetLength(0) - 1))
            {
                escritura.WriteLine();
            }

        }
        escritura.Close();
    }
    public static void EscribirCambiosAlta(string path, string[,] arreglo)
    {
        StreamWriter escritura = File.CreateText(path);
        for (int j = 0; j < arreglo.GetLength(0); j++)
        {
            for (int i = 0; i < arreglo.GetLength(1); i++)
            {
                if (i == arreglo.GetLength(1) - 1)
                {
                    escritura.Write(arreglo[j, i]);
                }
                else
                {
                    escritura.Write(arreglo[j, i]);
                    escritura.Write(',');  //Va a existir una coma al final
                }
            }
            escritura.WriteLine();
        }
        escritura.Close();
    }
     public static void EscribirCambiosAltaLibros(string path2, string[,] arreglo)
    {
        StreamWriter escritura = File.CreateText(path2);
        for (int j = 0; j < arreglo.GetLength(0); j++)
        {
            for (int i = 0; i < arreglo.GetLength(1); i++)
            {
                if (i == arreglo.GetLength(1) - 1)
                {
                    escritura.Write(arreglo[j, i]);
                }
                else
                {
                    escritura.Write(arreglo[j, i]);
                    escritura.Write(',');  //Va a existir una coma al final
                }
            }
            escritura.WriteLine();
        }
        escritura.Close();
    }
}