using System.Collections.Generic;

public class Witch : Villager
{
    private List<Item> Items { get; set; }

    public Witch(string _name) : base(_name)
    {
        this.Health = 100;
        this.Messages = new List<string> { "Hello", "Wanna enchant something?" };
        this.Name = _name;
        this.Role = "Witch";
    }

    private void Trade()
    {
        // trade with player
    }

    private void Enchant()
    {
        // enchant something for player
    }
}
