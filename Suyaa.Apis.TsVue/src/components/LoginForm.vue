<script setup lang="ts">
import { ref } from 'vue'
import loginUserImage from '/login/user.png'
import loginPwdImage from '/login/password.png'
import { def } from '@vue/shared';

let isUserFocus = ref(false);
let isPwdFocus = ref(false);

// 设置用户焦点
const setUserFocus = function (isFocus: boolean) {
    isUserFocus.value = isFocus;
}

// 设置密码焦点
const setPwdFocus = function (isFocus: boolean) {
    isPwdFocus.value = isFocus;
};
</script>

<template>
    <div class="login-box" id="login">
        <div class="login-rect">
            <div class="login-bg"></div>
            <div class="login-form">
                <p :class="{ selected: isUserFocus }"><img :src="loginUserImage" /><input placeholder="输入用户名" type="text"
                        maxlength="50" @focus="setUserFocus(true)" @blur="setUserFocus(false)" /><br /></p>
                <p :class="{ selected: isPwdFocus }"><img :src="loginPwdImage" /><input placeholder="输入密码" type="password"
                        maxlength="50" @focus="setPwdFocus(true)" @blur="setPwdFocus(false)" /><br /></p>
                <div>
                    <div class="forgot"><a href="javascript:;">忘记密码</a></div>
                    <div class="submit"><a href="javascript:;">确认登录</a></div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.login-box {
    width: 360px;
    height: 234px;
    position: fixed;
    z-index: 100;
    left: 50%;
    top: 50%;
    margin-left: -180px;
    margin-top: -160px;
    overflow: hidden;
    border-radius: 10px;
    box-shadow: 1px 1px 50px #222222;
}

.login-rect {
    width: 100%;
    height: 100%;
    position: relative;
}

.login-bg {
    width: 100%;
    height: 100%;
    background: #e0e0e0;
    opacity: 0.9;
}

.login-form {
    position: absolute;
    left: 50px;
    top: 50px;
    width: calc(100% - 100px);
}

.login-form p {
    display: block;
    width: 100%;
    margin: 0 0 20px 0;
    padding: 5px;
    border: 1px solid #a0a0a0;
    background: #fff;
    border-radius: 4px;
    box-shadow: 0px 0px 1px #a0a0a0;
}

.login-form .selected {
    border: 1px solid #ff6600 !important;
    box-shadow: 0px 0px 1px #ff6600 !important;
}

.login-form img {
    display: block;
    float: left;
    width: 20px;
    height: 20px;
    border: 0px;
    margin: 2px 2px 0 2px;
}

.login-form input {
    display: block;
    float: left;
    margin-left: 5px;
    width: calc(100% - 29px);
    height: 24px;
    line-height: 24px;
    font-size: 14px;
    border: 0px;
}

.login-form .forgot {
    float: left;
}

.login-form .forgot a {
    display: block;
    text-decoration: none;
    color: #888888;
    line-height: 34px;
    font-size: 12px;
}

.login-form .forgot a:hover {
    color: #333333;
}

.login-form .submit {
    float: right;
}

.login-form .submit a {
    display: block;
    width: 100px;
    height: 34px;
    line-height: 34px;
    background: #0077cc;
    text-align: center;
    text-decoration: none;
    color: #fff;
    border-radius: 4px;
    box-shadow: 0px 0px 1px #0077cc;
}

.login-form .submit a:hover {
    background: #0094ff;
}

.login-form br {
    display: block;
    clear: both;
}
</style>