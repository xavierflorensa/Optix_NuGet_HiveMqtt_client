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
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        // Setup Client options and instantiate
        /*var options = new HiveMQClientOptionsBuilder().WithBroker("broker.hivemq.com")
            .WithPort(1883)
            .WithUseTls(false)
            .Build();
    */
       //var client = new HiveMQClient(options);
        // Connect to the MQTT broker
        //var connectResult = await client.ConnectAsync().ConfigureAwait(false);
        // Publish a message
        //var publishResult = await client.PublishAsync("topic1/example", "Hello World");
        
        }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
    [ExportMethod]
    
    public async void Publish(NodeId textboxNodeId)
    {
        // Setup Client options and instantiate
        var options = new HiveMQClientOptionsBuilder().WithBroker("broker.hivemq.com")
            .WithPort(1883)
            .WithUseTls(false)
            .Build();
        var client = new HiveMQClient(options);
        // Connect to the MQTT broker
        var connectResult = await client.ConnectAsync().ConfigureAwait(false);
        // Publish a message
         var textbox = InformationModel.Get<TextBox>(textboxNodeId);
         string messagetosend = textbox.Text;
         var publishResult = await client.PublishAsync("topic1/example", messagetosend);
    }

    
}
