namespace Zaxiure.HyprlandCsharp.Events.Models;

public class EventType
{
    protected SocketCommandConnection _commandSocket { get; set; }

    public virtual async Task AfterObjectCreation(SocketCommandConnection socket)
    {

    }

    public void FillProperties(SocketCommandConnection socket, string[] data)
    {
        _commandSocket = socket;
        var props = GetType().GetProperties();
        props.Select((item, index) => (item, index)).ToList().ForEach(x =>
        {
            var item = x.item;
            var index = x.index;
            if (index < data.Length)
            {
                var value = data[index];
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(this, data[index]);
                }

                if (item.PropertyType == typeof(bool))
                {
                    if (value == "1" || value == "0")
                    {
                        item.SetValue(this, value == "1");
                    }
                    else if(value == "true" || value == "false")
                    {
                        item.SetValue(this, value == "true");
                    }
                }

                if (item.PropertyType == typeof(int))
                {
                    item.SetValue(this, int.Parse(data[index]));
                }
            }
        });
    }
}