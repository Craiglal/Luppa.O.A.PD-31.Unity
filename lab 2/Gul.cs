using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gul : Enemy
{
    public Gul(string _name) : base(_name)
    {
        this.Name = _name;
        this.Damage = 3;
        this.Health = 100;
    }

    protected override void Move()
    {
        base.Move();
        //move close to nest
    }

    public override void Interact()
    {
        base.Attack();
    }
}
