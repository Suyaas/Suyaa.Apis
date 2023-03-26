/**
 * Suyaa Api 操作类
 */
class Suyaa {
    /**
     * 以Get方式获取API内容
     * @param {string} url
     */
    async apiGet(url) {
        let response = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        if (response.status !== 200) console.error("Get '" + url + "' Status " + response.status);
        let res = await response.json();
        if (!res.success) throw res.message;
        return res.data;
    }
    /**
     * 以Post方式获取API内容
     * @param {string} url
     * @param {any} data
     */
    async apiPost(url, data) {
        let response = await fetch(url, {
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json"
            }
        });
        if (response.status !== 200) console.error("Post '" + url + "' Status " + response.status);
        let res = await response.json();
        if (!res.success) throw res.message;
        return res.data;
    }
    /**
     * 注册就绪事件
     * @param {void} fn 
     */
    onReady(fn) {
        let self = this;
        // 创建函数集
        if (typeof self._handles === "undefined") self._handles = [];
        // 添加函数
        self._handles.push(fn);
    }
    /**
     * 触发就绪事件 
     */
    raiseReadyEvent() {
        let self = this;
        if (typeof self._handles === "undefined") return;
        // 依次执行函数
        for (let i = 0; i < self._handles.length; i++) {
            self._handles[i]();
        }
        // 清空函数集合
        self._handles = [];
    }
}



/**
 * Suyaa Api 快速操作
 */
export const suyaa = new Suyaa();