using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

// Nessuna interfaccia Blazor: la pagina del portfolio disegna tutto e chiama Demox.Motore.Ponte.
var builder = WebAssemblyHostBuilder.CreateDefault(args);
var host = builder.Build();
Demox.Motore.Ponte.JS = (IJSInProcessRuntime)host.Services.GetRequiredService<IJSRuntime>();
Demox.Motore.Ponte.JS.InvokeVoid("demoxPronto");
await host.RunAsync();
