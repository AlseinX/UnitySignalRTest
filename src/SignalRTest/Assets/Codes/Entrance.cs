using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public IContainer Container { get; private set; }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        ConfigureServices();
        _ = Run();
    }

    private async Task Run()
    {
        var hub = Container.Resolve<HubConnection>();
        await hub.StartAsync();
        (var users, var rooms) = await hub.InvokeAsync<(int, int)>("Hello");
        Debug.Log($"{users},{rooms}");
    }

    private void ConfigureServices()
    {
        var builder = new ContainerBuilder();
        var hubConnectionBuilder = new HubConnectionBuilder().WithUrl("http://127.0.0.1:5000/fal");
        builder.Populate(hubConnectionBuilder.Services);
        Container = builder.Build();
    }
}
