using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vivern : Enemy
{
    public Vivern(string _name) : base(_name)
    {
        this.Name = _name;
        this.Damage = 10;
        this.Health = 200;
    }

    protected override void Move()
    {
         //fly in the air
    }

    public override void Interact()
    {
        base.Attack();
    }
}
