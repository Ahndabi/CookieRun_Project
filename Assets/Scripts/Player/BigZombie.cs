using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie : PlayerBase, IBiggable
{
    [SerializeField] ZombieTakeDamage zombieTakeDamage;
    bool isBig = false;

    void IBiggable.NoneDamage()     // Ŀ���� �ִϸ��̼� �̺�Ʈ�� ���� �Լ�
    {
        zombieTakeDamage = GetComponent<ZombieTakeDamage>();
        isBig = true;
        Destroy(zombieTakeDamage);
        StartCoroutine(OriginalSizeRoutine());
        StartCoroutine(AddTakeDamageRoutine());
    }

    IEnumerator OriginalSizeRoutine()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("Smaller");    // ���� ���·� ���ư� (�۾���)
        isBig = false;
    }

    protected virtual IEnumerator AddTakeDamageRoutine()
    {
        yield return new WaitForSeconds(4f);

        gameObject.AddComponent<ZombieTakeDamage>();      // �ٽ� TakeDamage ��ũ��Ʈ �߰�
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle" && isBig)
        {
            Destroy(col.gameObject);        // �ε��� ��ֹ��� Destroy
        }
    }
}