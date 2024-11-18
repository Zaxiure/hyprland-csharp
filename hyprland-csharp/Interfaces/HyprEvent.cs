using Zaxiure.HyprlandCsharp.Events.Models;

namespace Zaxiure.HyprlandCsharp.Interfaces;

public abstract class HyprEvent<T> where T : EventType, new()
{

    private Type type = typeof(T);

    public abstract void HandleEvent(T eventData);

    public Type GetGenericType()
    {
        return type;
    }

    public async Task<T?> CreateEventObject(SocketCommandConnection e,string[] data)
    {
        var newObject = new T();
        newObject.FillProperties(e, data);
        await newObject.AfterObjectCreation(e);
        return newObject;
    }
}