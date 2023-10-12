using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IBiggable     // �������� �԰� Ŀ�� �� �ִ� �������̽�
{
    protected void NoneDamage();    // �÷��̾ Ŀ���� �ִϸ��̼ǿ� �̺�Ʈ�� ���� �Լ�

    /* ���� BigPlayer�� �ִ� ����
     * 
    TakeDamage takeDamage;
    Animator anim;
    bool isBig = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void NoneDamage() // �÷��̾ Ŀ���� �ִϸ��̼ǿ� �̺�Ʈ�� ���� �Լ�
    {
        takeDamage = GetComponent<TakeDamage>();
        isBig = true;
        Destroy(takeDamage);
        StartCoroutine(OriginalSizeRoutine());
        StartCoroutine(AddTakeDamageRoutine());
    }

    IEnumerator OriginalSizeRoutine()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("Smaller");     // ���� ���·� ���ư� (�۾���)
        isBig = false;
    }

    protected virtual IEnumerator AddTakeDamageRoutine()
    {
        yield return new WaitForSeconds(4f);

        gameObject.AddComponent<TakeDamage>();      // �ٽ� TakeDamage ��ũ��Ʈ �߰�
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle" && isBig)
        {
            Destroy(col.gameObject);        // �ε��� ��ֹ��� Destroy
        }
    }*/
}
