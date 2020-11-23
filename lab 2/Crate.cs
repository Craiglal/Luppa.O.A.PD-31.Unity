using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : LootBox
{
    private List<Item> Items { get; set; }

    public Crate(string _name)
    {
        this.Name = _name;
        this.Type = "LootBox";
        this.Description = "Crate with loot";
        Items = new List<Item> { new Posion("Derfer"), new Heal("Song of angles") };
    }

    public override void Interact()
    {
        base.Interact();
        //Open crate for loot
    }
}
