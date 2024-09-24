
using System.ComponentModel.DataAnnotations;

namespace Project.Core.Entities.General;

//Base class for entities common properties
public class Base<T>
{
    [Key]
    public T? Id { get; set; }
}