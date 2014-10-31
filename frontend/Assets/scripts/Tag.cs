using System.Collections;
using UnityEngine;

public class Tag : MonoBehaviour
{
    private string name = "none";

    public Tag(string name)
	{
        this.name = name;
	}

    void Awake()
    {

    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public bool IsValid()
    {
        return true;
    }
}
