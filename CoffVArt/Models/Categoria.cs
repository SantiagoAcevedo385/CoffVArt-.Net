using System;
using System.Collections.Generic;

namespace CoffVArt.Models;

public partial class Categoria
{
    public int IdCategorias { get; set; }

    public string Nombre { get; set; } = null!;

    public int ProveedorId { get; set; }

    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
