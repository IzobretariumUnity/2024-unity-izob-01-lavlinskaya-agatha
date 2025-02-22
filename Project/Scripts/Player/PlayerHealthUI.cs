using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject prefabHealth;

    private GameObject parent;

    public List<GameObject> objectsHealth = new List<GameObject>();

    private float shift = 140f;

    private void Start()
    {
        ParentInit();
    }

    public void Init(int maxHealth, int currentHealth)
    {
        Debug.Log(maxHealth);
        Debug.Log(currentHealth);

        for(int i = 0; i < maxHealth; i++)
        {
            if(parent == false)
            {
                ParentInit();
            }

            GameObject obj = Instantiate(prefabHealth, parent.transform, false);
            Vector3 pos = obj.transform.localPosition;
            obj.transform.localPosition = new Vector3(pos.x - i * shift, pos.y, pos.z);
            objectsHealth.Add(obj);
        }

        UpdateUI(currentHealth);
    }

    public void UpdateUI(int health)
    {
        for(int i = 0; i < objectsHealth.Count; i++)
        {
            objectsHealth[i].SetActive(i < health);
        }
    }

    private void ParentInit()
    {
        parent = GameObject.FindGameObjectWithTag("ui_HealthBar");
    }
}
