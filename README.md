# Blazor MindMap 思维导图组件

示例:

https://blazor.app1.es/MindMaps

使用方法:

1.nuget包

```BootstrapBlazor.MindMap```

2._Imports.razor 文件 或者页面添加 添加组件库引用

```@using BootstrapBlazor.Components```


3.razor页面
```
<a href="https://github.com/densen2014/Densen.Extensions/blob/master/Demo/DemoShared/Pages/MindMaps.razor"><h5>页面源码</h5></a>

<p>Tab:添加新节点</p>
<p>鼠标可拖动节点排列</p>

<MindMap @ref="MindMap" OnReceive="@OnReceive" OnError="@OnError" />

<Textarea @bind-Value="Message" />

<Button Text="下载为PNG" OnClick="Export" />
<Button Text="下载为json" OnClick="ExportJson" />
<Button Text="导出PNG" OnClick="ExportPng" />
<Button Text="导出对象" OnClick="GetFullData" />
<Button Text="导出json对象" OnClick="GetData" />
<Button Text="导入数据(json)" OnClick="SetData" />
<Button Text="复位" OnClick="Reset" />



@code{

    [NotNull]
    MindMap? MindMap;

    new string? Message { get; set; } = "";

    private Task OnReceive(string? message)
    {
        Message = message;
        return Task.CompletedTask;
    }

    private Task OnError(string message)
    {
        Message = message;
        return Task.CompletedTask;
    }

    async Task Export()
    {
        await MindMap.Export();
        await ShowBottomMessage("下载Png");
    }

    async Task ExportJson()
    {
        await MindMap.Export("json", WithConfig: false);
        await ShowBottomMessage("下载Json");
    }

    async Task ExportPng()
    {
        await MindMap.Export(IsDownload:false, WithConfig: false);
        await ShowBottomMessage("已导出Png");
    }

    async Task GetFullData()
    {
        await MindMap.GetData();
    }

    async Task GetData()
    {
        await MindMap.GetData(false);
    }

    async Task SetData()
    {
        if (Message != null) await MindMap.SetData(Message);
    }

    async Task Reset()
    {
        await MindMap.Reset();
    }
}
```
----
#### 更新历史


---
#### Blazor 组件

[条码扫描 ZXingBlazor](https://www.nuget.org/packages/ZXingBlazor#readme-body-tab)
[![nuget](https://img.shields.io/nuget/v/ZXingBlazor.svg?style=flat-square)](https://www.nuget.org/packages/ZXingBlazor) 
[![stats](https://img.shields.io/nuget/dt/ZXingBlazor.svg?style=flat-square)](https://www.nuget.org/stats/packages/ZXingBlazor?groupby=Version)

[图片浏览器 Viewer](https://www.nuget.org/packages/BootstrapBlazor.Viewer#readme-body-tab) 

[手写签名 SignaturePad](https://www.nuget.org/packages/BootstrapBlazor.SignaturePad#readme-body-tab)

[定位/持续定位 Geolocation](https://www.nuget.org/packages/BootstrapBlazor.Geolocation#readme-body-tab)

[屏幕键盘 OnScreenKeyboard](https://www.nuget.org/packages/BootstrapBlazor.OnScreenKeyboard#readme-body-tab)

[百度地图 BaiduMap](https://www.nuget.org/packages/BootstrapBlazor.BaiduMap#readme-body-tab)

[谷歌地图 GoogleMap](https://www.nuget.org/packages/BootstrapBlazor.Maps#readme-body-tab)

[蓝牙和打印 Bluetooth](https://www.nuget.org/packages/BootstrapBlazor.Bluetooth#readme-body-tab)

[PDF阅读器 PdfReader](https://www.nuget.org/packages/BootstrapBlazor.PdfReader#readme-body-tab)

[文件系统访问 FileSystem](https://www.nuget.org/packages/BootstrapBlazor.FileSystem#readme-body-tab)

[光学字符识别 OCR](https://www.nuget.org/packages/BootstrapBlazor.OCR#readme-body-tab)

[电池信息/网络信息 MindMap](https://www.nuget.org/packages/BootstrapBlazor.MindMap#readme-body-tab)

[文件预览 FileViewer](https://www.nuget.org/packages/BootstrapBlazor.FileViewer#readme-body-tab)

[视频播放器 VideoPlayer](https://www.nuget.org/packages/BootstrapBlazor.VideoPlayer#readme-body-tab)

[图像裁剪 ImageCropper](https://www.nuget.org/packages/BootstrapBlazor.ImageCropper#readme-body-tab)

[视频播放器 BarcodeGenerator](https://www.nuget.org/packages/BootstrapBlazor.BarcodeGenerator#readme-body-tab)

#### AlexChow

[今日头条](https://www.toutiao.com/c/user/token/MS4wLjABAAAAGMBzlmgJx0rytwH08AEEY8F0wIVXB2soJXXdUP3ohAE/?) | [博客园](https://www.cnblogs.com/densen2014) | [知乎](https://www.zhihu.com/people/alex-chow-54) | [Gitee](https://gitee.com/densen2014) | [GitHub](https://github.com/densen2014)
 