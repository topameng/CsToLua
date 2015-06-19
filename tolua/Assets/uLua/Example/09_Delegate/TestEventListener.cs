using UnityEngine;
using System;
using System.Collections;

public class TestEventListener : MonoBehaviour
{
    public Action<GameObject> OnClick = null;
}
