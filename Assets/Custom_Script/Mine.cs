using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
  /*  //���� ���� ������
    Vector3 boxSize;

    //���� ����
    int maxDistance = 6;

    RaycastHit[] hitArray;*/

    RaycastHit hit;

    [SerializeField] GameObject explosion;
    [SerializeField] GunData mine;
    GameObject explosion_prefab;

    int damage = 200;

    IDamageable[] target;
    Transform thisObject;

    int distance;


    // Start is called before the first frame update
    void Start()
    {
        //boxSize = this.transform.localScale * 2;
        thisObject = this.gameObject.GetComponent<Transform>();
        distance = 7;
    }

    // Update is called once per frame
    void Update()
    {
        Damage();
    }

    void Damage()
    {
        /*RaycastHit[] hitArray = Physics.BoxCastAll(transform.position, boxSize, transform.forward, this.transform.rotation, Mathf.Infinity);

        for(int i=0; i< hitArray.Length; i++)
        {
            if (hitArray[i].collider.gameObject.tag != "Player")
            {
                target[i] = hitArray[i].collider.GetComponent<IDamageable>();
                target[i].OnDamage(damage, hitArray[i].point, hitArray[i].point);
            }
        }*/


        if (Physics.Raycast(thisObject.position, thisObject.up, out hit, distance) && hit.collider.gameObject.tag != "Player")
        {
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            // �������� ���� IDamageable ������Ʈ�� �������µ� �����ߴٸ�
            if (target != null)
            {
                // ������ OnDamage �Լ��� ������Ѽ� ���濡�� ������ �ֱ�
                target.OnDamage(mine.damage, hit.point, hit.normal);
            }

            explosion_prefab = Instantiate(explosion, thisObject.position, thisObject.rotation);
            //Explosion.Play();
            Invoke("Destroy", 2.0f);
        }
    }

    void Destroy()
    {
        Destroy(explosion_prefab);
        Destroy(this.gameObject);
    }
}

