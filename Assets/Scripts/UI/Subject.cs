using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour, ISubject
{
    public virtual void AddObserver(Observer observer)
    {

    }
    public virtual void RemoveObserver(Observer observer)
    {

    }
    public virtual void NotifyObservers()
    {

    }
}
