using System;

namespace baseApp.Src.Modules.Provider.Domain;

public class domain
{
abstract class Provider
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
