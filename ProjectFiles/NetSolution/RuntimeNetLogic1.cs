#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using HiveMQtt.Client;
using HiveMQtt.MQTT5.Types;
using System.Net.Http;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override async void Start()
    {
        bool abuttonispressed=false;
        var Abuttonispressed = Project.Current.GetVariable("Model/AButtonIsPressed");
        // Setup Client options and instantiate
        var options = new HiveMQClientOptionsBuilder().WithBroker("broker.hivemq.com")
            .WithPort(1883)
            .WithUseTls(false)
            .Build();
    
        var client = new HiveMQClient(options);
        // Connect to the MQTT broker
        var connectResult = await client.ConnectAsync().ConfigureAwait(false);
        //hold until a button is pressed
        while (true)
        {
            while (!abuttonispressed)
            {
            //holds until a button is pressed
           
            abuttonispressed = Abuttonispressed.Value;
            }
        // Publish a message
        var Messagetosend = Project.Current.GetVariable("Model/Message");
        string payload = Messagetosend.Value;
        //var publishResult = await client.PublishAsync("topic1/example", Messagetosend.Value);
        var publishResult = await client.PublishAsync("topic1/example", payload);
        abuttonispressed=false;
        Abuttonispressed.Value=false;
        }

        // Publish a message
        //var publishResult = await client.PublishAsync("topic1/example", "Hello World");
        
        }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
    [ExportMethod]
    
    public void Publish()
    {
        var Abuttonispressed = Project.Current.GetVariable("Model/AButtonIsPressed");
        Abuttonispressed.Value=true;
    }

    
}
