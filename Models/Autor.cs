using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Actividad4ApiSegura.Models;

[Table("Autor")]
public partial class Autor
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Nacionalidad { get; set; }

    public int? AnioNacimiento { get; set; }

    [InverseProperty("Autor")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
