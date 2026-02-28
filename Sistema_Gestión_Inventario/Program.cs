


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
                Console.WriteLine("6. Ver productos eliminados");
                Console.WriteLine("7. Salir");

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

                        case 3:
                        VerProductos(ListProducto);
                        break;

                        case 4:
                        AbastecerProducto(ListProducto);
                        break;

                        case 5:
                        EliminarProducto(ListProducto);
                        break;

                        case 6:
                        VerProductosEliminados(ListProducto);
                        break;

                        case 7:
                        return;
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

        string estado = "Activo";
        Producto nuevo = new Producto(nombre, precio, cantidad, estado);

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
            if(p.Nombre == nombre || p.Estado == "Activo")
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

    public static void VerProductos(List<Producto> productos)
    {
        Console.WriteLine($"{"Nombre",-10} {"Precio",-10} {"Cantidad",-10} {"Estado",-10}");
        foreach(Producto p in productos)
        {
           if(p.Estado == "Activo")
            {
                Console.WriteLine($"{p.Nombre,-10} {p.Precio,-10} {p.Cantidad,-10} {p.Estado,-10}");
            }
           
        }
    }

    
    public static void AbastecerProducto(List<Producto> productos)
    {
        Console.WriteLine("Ingrese el nombre del producto");
        string nombre = Console.ReadLine();

        Console.WriteLine("Agregar la cantidad");
        if(!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Cantidad invalidad");
            return;
        }
        else if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad no puede ser menor o igual a cero");
        }
        foreach(Producto p in productos)
        {
            if(p.Nombre == nombre)
            {
                p.Cantidad += cantidad;
                Console.WriteLine("Abastecimiento exitoso");
            }
        }
    }

    public static void EliminarProducto(List<Producto> productos)
    {
        Console.WriteLine("Ingrese el nombre del producto a eliminar");
        string nombre = Console.ReadLine();

        foreach(Producto p in productos)
        {
            if(p.Nombre == nombre)
            {
                p.Estado = "Eliminado";
                Console.WriteLine("Producto eliminado");
            }
        }
    }

    public static void VerProductosEliminados(List<Producto> productos)
    {
        Console.WriteLine($"{"Nombre",-10} {"Precio",-10} {"Cantidad",-10} {"Estado",-10}");
        foreach(Producto p in productos)
        {
            if(p.Estado == "Eliminado")
            {
                 Console.WriteLine($"{p.Nombre,-10} {p.Precio,-10} {p.Cantidad,-10} {p.Estado,-10}");
            }
        }
    }
}
