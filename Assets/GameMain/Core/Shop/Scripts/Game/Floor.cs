using UnityEngine;

public class Floor : MonoBehaviour
{
    private Interval m_interval;
    public Interval Interval
    {
        get
        {
            return m_interval;
        }
    }
    private void Awake()
    {
        m_interval = GetComponentInChildren<Interval>();
        EntityBase[] entities = GetComponentsInChildren<EntityBase>();
        for (int i = 0; i < entities.Length; i++)
        {
            entities[i].SetFloor(this);
        }
    }
}