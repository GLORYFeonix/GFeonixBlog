<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
let id: any = route.params.id
const markdown: any = ref('# 标题')

// Make a request for a user with a given ID
axios
  .get('http://localhost:5000/Post/GetPostById?id=' + id)
  .then(function (response)
  {
    // handle success
    markdown.value = response.data.markdown
    IMGreplace(response.data.title)
  })
  .catch(function (error)
  {
    // handle error
    console.log(error)
  })
  .finally(function ()
  {
    // always executed
  })

// TODO:前端处理图片链接的替换
function IMGreplace(title: string)
{
  const regex: RegExp = new RegExp('(!\\[.*\\])\\(.*(/{1}.*\\))', 'g')
  markdown.value = markdown.value.replaceAll(regex, '$1(/src/assets/blogs/' + title + '/img$2')
}
</script>

<script lang="ts">
export default {
  data()
  {
    return {
      markdown: '# 标题'
    }
  }
}
</script>

<template>
  <v-md-editor v-model="markdown" mode="preview" :default-show-toc="true" :include-level="[2, 3]"
    :toc-nav-position-right="false"></v-md-editor>
</template>

<style></style>
