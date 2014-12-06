using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TagParticle : MonoBehaviour {

    public Text label;

    public void Init(string tag)
    {
        label.text = tag;
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
