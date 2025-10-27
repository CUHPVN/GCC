using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : BaseItem
{
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        player.ChangePlayerColor(Color.red);
    }
}
