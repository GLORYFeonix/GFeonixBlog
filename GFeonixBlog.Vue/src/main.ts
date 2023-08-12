import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import highlight from 'highlight.js'

const app = createApp(App)

//创建指令
app.directive('highlight', function (el: any)
{
  let blocks = el.querySelectorAll('pre code');
  blocks.forEach((block: any) =>
  {
    highlight.highlightElement(block)
  })
})

app.use(createPinia())
app.use(router)

app.mount('#app')
