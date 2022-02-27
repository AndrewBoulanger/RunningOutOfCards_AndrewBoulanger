using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour
{
    public CardEffect mEffect;

    public Material defaultMaterial;

    public AudioSource audio;

    private void Start()
    {
        if(mEffect == null)
            mEffect = new CardEffect();
    }

    public void DoEffect(GameManager manager)
    {
        if(audio != null)
            audio.PlayOneShot(mEffect.GetSound);

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
        GetComponent<MeshRenderer>().material = mEffect.GetIcon;
    }


    private void OnDisable()
    {
        if(defaultMaterial != null)
            GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    public void DoubleCard()
    {
        if(mEffect != null)
            mEffect.multiplier *= 2;
    }
}
