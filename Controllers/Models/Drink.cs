using System;
using System.Collections.Generic;

namespace TacoBellAPI;

public partial class Drink
{
    public Drink(string name, float cost, bool slushie)
    {
        Name = name;
        Cost = cost;
        Slushie = slushie;
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? Slushie { get; set; }
}
