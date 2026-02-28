public class Producto
{
    private string _Nombre;

    private float _Precio;

    private int _Cantidad;

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

    public float Precio {
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


    public Producto(string nombre, float precio, int cantidad)
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

        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
}