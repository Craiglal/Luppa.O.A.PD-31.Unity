using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Item
{
    public Heal(string _name)
    {
        this.Description = "Heal player";
        this.Name = _name;
        this.Type = "Healer";
        this.Reusable = true;
        this.Usages = 3;
    }

    protected override void Recreate()
    {
        // refill heal
    }

    public override void Interact()
    {
        // Heal player if isn't empty
    }
}
