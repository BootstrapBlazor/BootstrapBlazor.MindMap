import MindMap from "/_content/BootstrapBlazor.MindMap/simpleMindMap.esm.min.js"

var mindMap = null;

export function Init(element, data) {

    var el = element.querySelector("[data-action=mindMapContainer]");

    //layout 布局类型，可选列表：logicalStructure（逻辑结构图）、mindMap（思维导图）、catalogOrganization（目录组织图）、organizationStructure（组织结构图）、timeline（v0.5.4+，时间轴）、timeline2（v0.5.4+，上下交替型时间轴）、fishbone（v0.5.4+，鱼骨图）
    if (mindMap == undefined) {
        mindMap = new MindMap({
            el: el,
            data: data
        });
    }

    return {
        dispose: () => {
            element.cloneNode(true);
        }
    }

}

export function Export(instance, type = 'png', isDownload = true, fileName = 'temp', withConfig = true) {  
    var ret=mindMap.export(type, isDownload, fileName, withConfig)
    if (!isDownload) instance.invokeMethodAsync('ReceiveData', ret);
}

// 获取数据
export async function GetData(instance, fullData = true) {
    instance.invokeMethodAsync('ReceiveData', JSON.stringify(mindMap.getData(fullData)));
}

// 导入数据
export function SetData(jsondata) {

    let data = JSON.parse(jsondata)
    // 如果数据中存在root属性，那么代表是包含配置的完整数据，则使用setFullData方法导入数据
    if (data.root) {
        mindMap.setFullData(data)
    } else {
        // 否则使用setData方法导入
        mindMap.setData(data)
    }
    // 导入数据后有可能新数据渲染在可视区域外了，所以为了更好的体验，可以复位一下视图的变换
    mindMap.view.reset()
}

export function Reset() {
    mindMap.view.reset()
}

//搜索替换
export function Search(searchInputRef) {
    mindMap.search.search(this.searchText, () => {
        searchInputRef.focus()
    })
}

export function Replace(replaceAll = false) {
    if (!replaceAll) {
        mindMap.search.replace(this.replaceText, true)
    } else {
        mindMap.search.replaceAll(this.replaceText)
    }
}

function download(dataURL, filename) {
    if (navigator.userAgent.indexOf("Safari") > -1 && navigator.userAgent.indexOf("Chrome") === -1) {
        window.open(dataURL);
    } else {
        var blob = dataURLToBlob(dataURL);
        var url = window.URL.createObjectURL(blob);

        var a = document.createElement("a");
        a.style = "display: none";
        a.href = url;
        a.download = filename;

        document.body.appendChild(a);
        a.click();

        window.URL.revokeObjectURL(url);
    }
}
