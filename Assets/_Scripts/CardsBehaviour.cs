using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour
{
    public CardEffect mEffect;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoEffect(GameManager manager)
    {
        transform.localScale *= 1.3f;
        mEffect.DoEffect(manager);
    }

    public void OnUsedUp()
    {
        transform.localScale = Vector3.one;
        mEffect = null;
    }

    public void Reveal()
    {
        GetComponent<MeshRenderer>().material = mEffect.icon;
    }

}
