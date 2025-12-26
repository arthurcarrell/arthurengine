namespace arthurengine.Entities;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;

public abstract class Entity
{
    // this is the most barebones class, doesnt actually do anything
    protected Dictionary<Type, object> components = new Dictionary<Type, object>();
    private string ID;

    // used to increment ID
    private static int usedIDs = 0;

    public Entity(string id = null)
    {
        if (id == null)
        {
            if (usedIDs > 0)
            {
                ID = $"{this.GetType()}{usedIDs}";
            }
            else
            {
                ID = $"{this.GetType()}";
            }
        }
        else
        {
            ID = id;
        }
        usedIDs++;
    }

    /// <summary>
    /// Gets a component that is attached to this entity.
    /// Will throw if the component cannot be found.
    /// </summary>
    public T GetComponent<T>()
    {
        return (T)components[typeof(T)];
    }

    public bool HasComponent<T>()
    {
        return components.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Adds a component to this entity.
    /// Returns the component you are adding.
    /// </summary>
    protected T AddComponent<T>(T component)
    {
        components.Add(typeof(T), component);
        return component;
    }

    public virtual void Update(GameTime gameTime)
    {
        // code here is run every frame;
    }

    public string GetID()
    {
        return ID;
    }
}
