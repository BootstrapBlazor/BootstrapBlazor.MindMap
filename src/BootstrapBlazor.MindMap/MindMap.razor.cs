// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using static BootstrapBlazor.Components.MindMapNode;

namespace BootstrapBlazor.Components;

/// <summary>
/// 思维导图 MindMap<para>开发文档 https://wanglin2.github.io/mind-map/#/doc/zh/introduction/?WT.mc_id=DT-MVP-5005078</para>
/// </summary>
public partial class MindMap : IAsyncDisposable
{
    [Inject] private IJSRuntime? JS { get; set; }
    private IJSObjectReference? module;
    private DotNetObjectReference<MindMap>? Instance { get; set; }

    /// <summary>
    /// UI界面元素的引用对象
    /// </summary>
    public ElementReference Element { get; set; }

    /// <summary>
    /// 获得/设置 错误回调方法
    /// </summary>
    [Parameter]
    public Func<string, Task>? OnError { get; set; }

    /// <summary>
    /// 获得/设置 收到数据回调方法
    /// </summary>
    [Parameter]
    public Func<string?, Task>? OnReceive { get; set; }

    /// <summary>
    /// 自定义CSS/Custom CSS
    /// </summary>
    [Parameter]
    [NotNull]
    public string? StyleCss { get; set; }

    /// <summary>
    /// 获得/设置 显示内置UI
    /// </summary>
    [Parameter]
    public bool ShowUI { get; set; } = true;

    /// <summary>
    /// 初始数据
    /// </summary>
    [Parameter]
    public MindMapNode Data { get; set; } = new MindMapNode
    {
        Data = new NodeData
        {
            Text = "根节点",
            Generalization = new Generalization
            {
                Text = "概要的内容"
            },
        }
    };

    private MindMapNode? OptionsCache { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (firstRender)
            {
                module = await JS!.InvokeAsync<IJSObjectReference>("import", "./_content/BootstrapBlazor.MindMap/MindMap.razor.js" + "?v=" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                Instance = DotNetObjectReference.Create(this);
                await module!.InvokeVoidAsync("Init", Element, Data);
                OptionsCache = Data;
            }

            if (!firstRender && module != null && OptionsCache != Data)
            {
                await module!.InvokeVoidAsync("Init", Element, Data);
                OptionsCache = Data;
            }

        }
        catch (Exception e)
        {
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        await Task.CompletedTask;
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        Instance?.Dispose();
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }

    /// <summary>
    /// 下载为文件
    /// </summary>
    public virtual async Task Export(string Type = "png", bool IsDownload = true, string FileName = "temp", bool WithConfig = true)
    {
        try
        {
            await module!.InvokeVoidAsync("Export", Instance, Type, IsDownload, FileName, WithConfig);
        }
        catch
        {
        }
    }

    /// <summary>
    /// 获取数据
    /// </summary>
    public virtual async Task GetData(bool FullData = true)
    {
        try
        {
            await module!.InvokeVoidAsync("GetData", Instance, FullData);
        }
        catch
        {
        }
    }

    /// <summary>
    /// 导入数据
    /// </summary>
    public virtual async Task SetData(string JsonDataString)
    {
        try
        {
            await module!.InvokeVoidAsync("SetData", JsonDataString);
        }
        catch
        {
        }
    }

    /// <summary>
    /// 复位
    /// </summary>
    public virtual async Task Reset()
    {
        try
        {
            await module!.InvokeVoidAsync("Reset");
        }
        catch
        {
        }
    }

    /// <summary>
    /// 收到数据回调方法
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    [JSInvokable]
    public async Task ReceiveData(object? msg)
    {
        try
        {
            if (OnReceive != null && msg != null)
            {
                await OnReceive.Invoke(msg.ToString());
            }
        }
        catch (Exception e)
        {
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

}
