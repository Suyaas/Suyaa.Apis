import { createApp } from "../share/vue.esm-browser.prod.js";
import { suyaa } from "../share/suyaa.js";

// 登录应用
const appLogin = createApp({
    data() {
        return {
            isUserFocus: false,
            isPwdFocus: false,
        }
    },
    async created() {
        let self = this;
    },
    methods: {
        // 设置用户名焦点
        setUserFocus(isFocus) {
            let self = this;
            self.isUserFocus = isFocus;
        },
        // 设置密码焦点
        setPwdFocus(isFocus) {
            let self = this;
            self.isPwdFocus = isFocus;
        },
    }
}).mount("#login");

// 消息应用