using System.Collections.Generic;

public class Blacksmith : Villager
{
    private List<Item> Items { get; set; }

    public Blacksmith(string _name) : base(_name)
    {
        this.Health = 100;
        this.Messages = new List<string> { "Hello", "Wanna trade?" };
        this.Name = _name;
        this.Role = "Blacksmith";
    }

    private void Trade()
    {
        // trade with player
    }

    private void Create()
    {
        // create something for player
    }
}
