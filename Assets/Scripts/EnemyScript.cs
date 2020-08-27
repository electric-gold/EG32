using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyScript : MonoBehaviour
{
    public static float EnemyHealth2;
    public GameObject Enemy;
    void Update()
    {
        CheckHealth();
    }
    void CheckHealth()
    {
        EnemyHealth2 = Shoot.EnemyHealth;
        if (EnemyHealth2 <= 0.75f)
        {
            Debug.Log("This is supposed to work!");
            this.gameObject.transform.position = (new Vector3(0f, -10f, 0f));
            StartCoroutine(Respawn());
            this.gameObject.transform.position = (new Vector3(-6f, 1f,0f));
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2.5f * Time.deltaTime);
    }
}
