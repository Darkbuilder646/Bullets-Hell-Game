using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            KillBullet();
        }
    }
}
