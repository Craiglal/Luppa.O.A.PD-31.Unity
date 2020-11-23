using System.Collections.Generic;

public class NPC : Interactable
{
    protected string Name { get; set; }
    protected string Role { get; set; }
    protected int Health { get; set; }
    protected List<string> Messages{ get; set; }

    protected virtual void Move(){ }

    protected virtual void Talk(){ }
}
