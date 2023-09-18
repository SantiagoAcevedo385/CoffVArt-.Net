using System;
using System.Collections.Generic;

namespace CoffVArt.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public DateTime FechaCompra { get; set; }

    public int ProveedorId { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
