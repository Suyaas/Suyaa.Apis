// import { createApp } from "../share/vue.esm-browser.js";
import { createApp } from "../share/vue.esm-browser.prod.js";
import { suyaa } from "../share/suyaa.js";
// fetch("/app/Common/Product/GetInfo1")
//     .then((response) => {
//         console.log(response.status);
//         response.text().then((data) => {
//             console.log(data)
//         })
//     }, (err) => {
//         console.log(err)
//     })

// 初始化编辑器
const codeggInit = function () {
    var obj = {};
    // 实例化一个对象
    let codegg = obj.codegg = new LarkCodegg("editor", {
        // colors: {
        //     borderColor: "#cccccc",
        //     toolbarItemColor: "#d81e06",
        //     toolbarItemBackgroudColorHover: "#ffffff",
        //     toolbarBackgroundColor: "#ebebeb",
        //     toolbarSpliteColor: "#dddddd",
        // },
        // toolbar: [["h1", "h2", "h3", "p", "div"], ["b", "i", "s"], ["table", "ol", "ul"], ["link", "image", "audio", "video"], ["view"]]
    });
    // 绑定错误
    codegg.bind("error", function (ex) {
        alert(ex);
    });
    // 获取内容
    obj.getContent = function () {
        //alert(codegg.getContent());
        return codegg.getContent();
    }
    // 设置内容
    obj.setContent = function (content) {
        codegg.setContent(content);
    }
    return obj;
}

var app = createApp({
    data() {
        return {
            working: false,
            status: "就绪",
            output: "",
        }
    },
    created() {
        let self = this;
        // 初始化编辑器
        self.editor = codeggInit();
        // 绑定保存事件
        self.editor.codegg.bind("save", function () {
            if (self.working) return;
            self.working = true;
            self.status = "正在保存 ...";
            setTimeout(async () => {
                var data = await suyaa.apiPost("/app/Lark/Editor/Save", {
                    path: "temp",
                    content: self.editor.getContent()
                });
                self.working = false;
                self.status = "保存成功";
            }, 10);
            //alert("保存");
        });
        // 在初始化的时候进行获取
        self.getScriptContent()
    },
    methods: {
        async getScriptContent() {
            let self = this;
            // 获取内容
            let data = await suyaa.apiGet("/app/Lark/Editor/Get?path=temp");
            self.editor.setContent(data);
        },
        async excuteScript() {
            let self = this;
            if (self.working) return;
            self.working = true;
            self.status = "正在执行 ...";
            setTimeout(async () => {
                try {
                    var data = await suyaa.apiPost("/api/temp", {});
                    //console.log(data);
                    self.output = data;
                } catch (e) {
                    self.output = e;
                }
                self.working = false;
                self.status = "执行结束";
            }, 10);
        },
    }
}).mount("#panel");