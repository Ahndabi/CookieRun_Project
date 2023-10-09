using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetRange : MonoBehaviour
{
    [SerializeField] GameObject pet;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")  // �������̶� ������ �� �������� �� �θ𿡰� ������
        {
            col.gameObject.transform.position = Vector3.MoveTowards(col.gameObject.transform.position, pet.transform.position, 1f);
        }
    }
}
