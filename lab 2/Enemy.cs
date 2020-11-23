﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    protected string Name { get; set; }
    protected int Health { get; set; }
    protected int Damage { get; set; }

    public Enemy (string _name)
    {
        Name = _name;
    }

    protected virtual void Move() { }

    public virtual void Attack() 
    {
        //attack player within a range
    }
}
