<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink, RouterView } from 'vue-router'

var tab = ref("AboutMe")
</script>

<template>
  <div class="Page">
    <!-- TODO:SideBar的固定定位 -->
    <div class="SideBar">
      <Transition name="fade" appear>
        <div class="Index">
          <div class="title"
            style="display: flex; flex-direction: column; background-color: #222222; height: 110px; padding: 20px 0;">
            <span style="
              text-align: center;
              margin: 0 auto;
              margin-bottom: 10px;
              font-weight: normal;
              font-size: x-large;
              color: white;
            ">年华碎片</span>
            <span style="
              text-align: center;
              margin: 0 auto;
              font-weight: normal;
              font-size: small;
              color: white;
            ">华南地区最小养猪场</span>
          </div>
          <div class="Menu" style="
            display: flex;
            flex-direction: column;
            height: 100%;
            padding: 10px 0;
            background-color: white;
          ">
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <img src="@/assets/home.svg" alt="home" style="width: 1em; margin-right: 8px;">
                </div>
                <div style="display: inline-block;">
                  <span>首页</span>
                </div>
              </div>
            </RouterLink>
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <img src="@/assets/folder.svg" alt="folder" style="width: 1em; margin-right: 8px;">
                </div>
                <div style="display: inline-block;">
                  <span>归档</span>
                </div>
              </div>
            </RouterLink>
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <img src="@/assets/categories.svg" alt="categories" style="width: 1em; margin-right: 8px;">
                </div>
                <div style="display: inline-block;">
                  <span>分类</span>
                </div>
              </div>
            </RouterLink>
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <img src="@/assets/tags.svg" alt="tags" style="width: 1em; margin-right: 8px;">
                </div>
                <div style="display: inline-block;">
                  <span>标签</span>
                </div>
              </div>
            </RouterLink>
          </div>
        </div>
      </Transition>
      <Transition name="fade" appear>
        <div class="About">
          <div class="Tabs">
            <div class="Tab" @click="tab = 'AboutMe'">
              <span>关于我</span>
            </div>
            <div class="Tab" @click="tab = 'Catalog'">
              <span>目录</span>
            </div>
            <div class="Tab" @click="tab = 'Links'">
              <span>相关链接</span>
            </div>
          </div>
          <hr class="hr-shadow">
          <div class="TabContent">
            <div class="AboutMe" v-show="tab == 'AboutMe'">
              <img src="@/assets/avatar.png" alt="avatar"
                style="margin: 18px auto; margin-bottom: 9px; width: 126px; height: 126px; border-radius: 50%;">
              <span
                style="color: #555555; font-weight: bold; font-size: 20px; margin: 0 auto; margin-bottom: 9px;">GFeonix</span>
              <span
                style="color: #999999; font-weight: bold; font-size: 13px; margin: 0 auto; margin-bottom: 9px;">感谢孤独时代的陪伴</span>
              <div style="display: flex; flex-direction: row; justify-content: center; margin-bottom: 18px;">
                <div style="display: flex; flex-direction: column; color: #555555; padding: 0 10px;">
                  <span style="margin: 0 auto; font-weight: 600; font-size: large;">7</span>
                  <span style="font-size: normal;">日志</span>
                </div>
                <div style="display: flex; flex-direction: column; color: #555555; padding: 0 10px;">
                  <span style="margin: 0 auto; font-weight: 600; font-size: large;">4</span>
                  <span style="font-size: normal;">分类</span>
                </div>
                <div style="display: flex; flex-direction: column; color: #555555; padding: 0 10px;">
                  <span style="margin: 0 auto; font-weight: 600; font-size: large;">3</span>
                  <span style="font-size: normal;">标签</span>
                </div>
              </div>
              <div style="display: flex; flex-direction: row; justify-content: center;">
                <img src="@/assets/QQ.svg" alt="QQ" style="width: 2em; margin: 0 4px;">
                <img src="@/assets/wechat.svg" alt="Wechat" style="width: 2em; margin: 0 4px;">
                <img src="@/assets/e-mail.svg" alt="E-mail" style="width: 2em; margin: 0 4px;">
                <img src="@/assets/github.svg" alt="Github" style="width: 2em; margin: 0 4px;">
              </div>
            </div>
            <div class="Catalog" v-show="tab == 'Catalog'" />
            <div class="Links" v-show="tab == 'Links'" />
          </div>
        </div>
      </Transition>
    </div>
    <Transition name="fade" appear>
      <div class="Main">
        <RouterView />
      </div>
    </Transition>
  </div>
</template>

<style scoped>
.Page {
  grid-column: span 2;
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
  justify-content: center;
}

.SideBar {
  display: flex;
  flex-direction: column;
  height: 100%;
  width: 240px;
  margin-right: 14px;
  /* position: fixed; */
}

.Index {
  height: 290px;
  margin-bottom: 14px;
  display: flex;
  flex-direction: column;
}

.Menu-Items {
  display: flex;
  flex-direction: row;
  height: 25%;
  color: black;
  margin-left: 10px;
  line-height: 40px;
  text-align: center;
  font-weight: 100;
  font-size: small;
}

.About {
  height: 440px;
  display: flex;
  flex-direction: column;
  background-color: white;
}

.Tabs {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}

.Tab {
  padding: 10px;
  margin: 10px 0;
  color: black;
}

.Tab:hover {
  text-decoration: underline;
  background-color: hsla(160, 100%, 37%, 0.2);
}

.hr-shadow {
  border: 0;
  padding-top: 10px;
  color: #d0d0d5;
  border-top: 1px solid rgba(0, 0, 0, .1);
  box-shadow: inset 0 10px 10px -10px;
}

.TabContent {
  display: flex;
  flex-direction: column;
}

.AboutMe {
  display: flex;
  flex-direction: column;
}

/* TODO:目录的样式 */
.Catalog {
  /* flex: 1;
  overflow: auto;
  padding: 4px 0;
  position: relative;
  width: 300px;
  height: 100%;
  margin: 0 auto; */
  color: black;
  padding-left: 20px;
}

.Catalog details {
  /* padding-left: 10px; */
  padding-left: 10px;
}

.Catalog summary {
  /* outline: 0; */
  /* padding-left: 20px; */
  /* list-style: none; */
}

.catalog-item {
  /* display: flex;
  align-items: center;
  height: 46px;
  font-size: 15px;
  line-height: 22px;
  color: rgba(0, 0, 0, 0.85);
  padding-left: 400px;
  margin-left: -400px;
  cursor: default; */
}

.Main {
  /* height: 100%; */
  width: 900px;
  /* margin-left: 254px; */
}

/* TODO:组件加载动画效果 */
/* .fade-enter-active,
.fade-leave-active {
  transition: opacity 3s ease;
}

.fade-enter-from,
.fade-leave-to {
  transform: translateY(100%);
  opacity: 0;
} */
</style>
