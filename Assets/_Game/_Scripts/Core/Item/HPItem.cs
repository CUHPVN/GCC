using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : BaseItem
{
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        player.ChangePlayerColor(Color.green);
    }
}
