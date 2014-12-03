using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerName : MonoBehaviour {

    public Text nameLabel;

    public void SetName(string name) { nameLabel.text = name; }
}
