using System;
using System.Collections.Generic;

namespace CoffVArt.Models;

public partial class Proveedore
{
    public int IdProveedores { get; set; }

    public int Nit { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Categoria> Categoria { get; set; } = new List<Categoria>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
