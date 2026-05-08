using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : Damage
{
    public bool activate;

    private void OnEnable()
    {
        activate = true;
        transform.localScale = new Vector3(0.57f, 0.57f, 0.57f);
    }

    private void Update()
    {
        if (activate)
            StartCoroutine(LaserScale(AttackSequence.Instance.laserfinalPos, AttackSequence.Instance.targetScale, AttackSequence.Instance.amplifyScale, AttackSequence.Instance.duration));
        else
            gameObject.SetActive(false);
    }
    IEnumerator LaserScale(float toMove, Vector3 toScale, Vector3 amplify, float time)
    {

        yield return new WaitForSeconds(2);

        Vector3 startingScale = transform.localScale;
        Vector3 startPos = transform.position;
        
        float elapsed = 0f;

        while (elapsed < time)
        {
            transform.position = Vector3.Lerp(startPos, new Vector2(transform.position.x, toMove), elapsed / time);
            Vector3 lerpScale = Vector3.Lerp(startingScale, toScale, elapsed / time);
            transform.localScale = lerpScale;
            elapsed += Time.deltaTime;
        }
        transform.localScale = toScale;    
        yield return new WaitForSeconds(0.5f);
        
        transform.localScale = Vector3.Lerp(transform.localScale, amplify, 0.5f);
        yield return new WaitForSeconds(3);
        activate = false;
        yield return null;
    }
}
