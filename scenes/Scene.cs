namespace arthurengine.Scenes;
using arthurengine.Entities;
using arthurengine.Components;
using System.Collections.Generic;

public class Scene
{
    private List<Entity> entities = new List<Entity>();
    private string ID;
    private Entity camera;

    public Scene(string id)
    {
        this.ID = id;
    }


    /// <summary>
    /// Gets the entity in the scene with the matched ID.
    /// </summary>
    /// <param name="id">The ID of the entity</param>
    /// <returns>Entity with matching ID</returns>
    /// <exception cref="KeyNotFoundException">No entity exists with that ID</exception>
    public Entity GetEntityByID(string id)
    {
        foreach (Entity entity in entities)
        {
            if (entity.GetID() == id) return entity;
        }
        throw new KeyNotFoundException("No entity with ID found.");
    }

    public List<Entity> GetEntities() { return entities; }
    public void AddEntity(Entity entity) => entities.Add(entity);
    public void RemoveEntity(Entity entity) => entities.Remove(entity);
    public string GetID() { return ID; }

    public void SetCamera(Entity entity)
    {
        if (!entity.HasComponent<CameraComponent>())
        {
            throw new Exception("Entity requires a CameraComponent in order to be set as a Camera");
        }

        if (!entity.HasComponent<TransformComponent>())
        {
            throw new Exception("Entity with a CameraComponent also needs a TransformComponent to be set as a Camera");
        }

        camera = entity;
    }

    public Entity GetCamera()
    {
        return camera;
    }
}
