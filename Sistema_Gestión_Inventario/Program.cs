
using System.Diagnostics.Contracts;

namespace Sistema_Gestión_Inventario;

class Progran
{
    static List<Producto> ListProducto = new List<Producto>();
    static void Main(string[] args)
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
    }


    public void AgregarProducto(List<Producto> productos)
    {
        Console.WriteLine("Ingrese el Nombre del producto");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el precio");
        decimal precio = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Ingrese la cantidad");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        Producto nuevo = new Producto(
        nombre,
        precio,
        cantidad
        );
    }

}
