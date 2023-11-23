using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPoint = Vector2.zero;

    public Vector3 RespawnPoint { get => respawnPoint; }

    public void RespawnPlayer(CharacterControler player)
    {
        StartCoroutine(Respawn(player));
        //Todo: Invinsibility on respawn
    }

    IEnumerator Respawn(CharacterControler player)
    {
        yield return new WaitForSeconds(2f);
        player.IsDead = false;
        player.gameObject.SetActive(true);
        player.transform.position = respawnPoint;
    }
}
