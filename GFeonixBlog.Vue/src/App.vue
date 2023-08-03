<script setup lang="ts">
import { CollectionTag } from '@element-plus/icons-vue';
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="Page">
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
                  <House style="width: 1em; height: 1em; margin-right: 8px" />
                </div>
                <div style="display: inline-block;">
                  <span>首页</span>
                </div>
              </div>
            </RouterLink>
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <MessageBox style="width: 1em; height: 1em; margin-right: 8px" />
                </div>
                <div style="display: inline-block;">
                  <span>归档</span>
                </div>
              </div>
            </RouterLink>
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <Menu style="width: 1em; height: 1em; margin-right: 8px" />
                </div>
                <div style="display: inline-block;">
                  <span>分类</span>
                </div>
              </div>
            </RouterLink>
            <RouterLink to="/list">
              <div class="Menu-Items">
                <div style="display: inline-block; vertical-align: middle;">
                  <CollectionTag style="width: 1em; height: 1em; margin-right: 8px" />
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
  height: 360px;
  display: flex;
  flex-direction: column;
  background-color: white;
}

.Main {
  height: 100%;
  width: 900px;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 3s ease;
}

.fade-enter-from,
.fade-leave-to {
  transform: translateY(100%);
  opacity: 0;
}
</style>
