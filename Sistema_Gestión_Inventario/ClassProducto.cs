public class Producto
{
    private string _Nombre;

    private decimal _Precio;

    private int _Cantidad;

    public string Estado;
    public string Nombre {
        get => _Nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Nombre invalido");
            }   

            _Nombre = value;
        }}

    public decimal Precio {
        get => _Precio;
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Precio invalido");
            }

            _Precio = value;
        }
    }

    public int Cantidad {
        get => _Cantidad;
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Cantidad invalida");
            }
            _Cantidad = value;
        }
    }


    public Producto(string nombre, decimal precio, int cantidad, string estado)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("EL nombre es invalido, Revise si tiene espacios");
        }
        else if(precio < 0)
        {
            throw new ArgumentException("EL precio no puede ser menor a cero");
        }
        else if(cantidad < 0)
        {
            throw new ArgumentException("La cantidad no puede ser menor a cero");
        }
        else if (string.IsNullOrWhiteSpace(estado))
        {
            throw new ArgumentException("El estado invalido");
        }

        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
        Estado = estado;
    }
}