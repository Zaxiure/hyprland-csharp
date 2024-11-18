using System.Net.Sockets;
using System.Reflection;
using System.Text.RegularExpressions;
using Grpc.Net.Client;
using Newtonsoft.Json;
using SmartFormat;
using Zaxiure.HyprlandCsharp.Interfaces;

namespace Zaxiure.HyprlandCsharp;

class Program
{
    static Socket socket;
    static Assembly assembly;
    public static SocketCommandConnection commandSocket;
    
    static async Task Main(string[] args)
    {
        var test = Environment.GetEnvironmentVariable("XDG_RUNTIME_DIR");
        assembly = Assembly.GetExecutingAssembly();

        commandSocket = new SocketCommandConnection();
        var socketConnection = new SocketEventConnection(commandSocket);
        socketConnection.StartReader();
    }
    
    public static IEnumerable<Type> GetTypesWithEventAttribute()
    {
        return assembly.GetTypes().Where(x =>
            x.BaseType != null && x.BaseType.IsGenericType &&
            x.BaseType.GetGenericTypeDefinition() == typeof(HyprEvent<>));
    }
}