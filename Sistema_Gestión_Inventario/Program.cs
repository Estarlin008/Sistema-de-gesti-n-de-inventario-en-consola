
using System.Data;
using System.Diagnostics.Contracts;

namespace Sistema_Gestión_Inventario;

class Progran
{
    static List<Producto> ListProducto = new List<Producto>();
    static void Main(string[] args)
    {
        try
        {

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("------------Menu---------------");
                Console.WriteLine("1. Ingresar productos");
                Console.WriteLine("2. Vender Producto");
                Console.WriteLine("3. Ver Productos en el inventario");
                Console.WriteLine("4. Abastecer producto");
                Console.WriteLine("5. Eliminar producto");
                Console.WriteLine("6. Salir");

                string imput = Console.ReadLine();

                if(int.TryParse(imput, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                        AgregarProducto(ListProducto);
                        break;

                        case 2:
                        VenderProducto(ListProducto);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Debe de ingresar un numero");
                }

                if (!salir)
                {
                    Console.WriteLine("/nPrecione S para salir del programa");
                    Console.ReadKey();
                }
        }
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public static void AgregarProducto(List<Producto> productos)
    {
        Console.WriteLine("Ingrese el Nombre del producto");
        string nombre = Console.ReadLine();

        foreach(Producto prod in productos)
        {
            if(prod.Nombre.ToLower() == nombre.ToLower())
            {
                Console.WriteLine("El Producto ya existe");
                return;
            }
        }

        Console.WriteLine("Ingrese el precio");
       if(!decimal.TryParse(Console.ReadLine(), out decimal precio))
        {
            Console.WriteLine("Precio invalido");
            return;
        }

        Console.WriteLine("Ingrese la cantidad");
        if(!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Cantidad invalidad");
            return;
        }

        Producto nuevo = new Producto(
        nombre,
        precio,
        cantidad
        );

        productos.Add(nuevo);
        Console.WriteLine("Producto registrado correctamente");
    }

    public static void VenderProducto(List<Producto> productos)
    {
        bool encontrado = false;
        Console.WriteLine("Ingrese el nombre del producto");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la cantidad del producto");
        if(!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Cantidad invalidad");
            return;
        }

        foreach(Producto p in productos)
        {
            if(p.Nombre.ToLower() == nombre.ToLower())
            {
                if(p.Cantidad >= cantidad)
                {
                    p.Cantidad -= cantidad;
                    Console.WriteLine("Venta valida");
                }
                encontrado = true;
                break;
            }

        }

        if (!encontrado)
        {
            Console.WriteLine("Producto no encontrado");
        }        
    }

}
