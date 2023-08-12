<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'
import { useRoute } from 'vue-router'

import 'github-markdown-css/github-markdown-light.css'
import 'highlight.js/styles/stackoverflow-light.css'

const route = useRoute()
let id: any = route.params.id
const htmltext: any = ref('# 标题')

//TODO:TOC和相关链接放左边
GetPostContent()
GetPostTOC()

function GetPostContent()
{
  // Make a request for a post with a given ID
  axios
    .get('http://localhost:5000/Post/GetPostById?id=' + id)
    .then(function (response)
    {
      // handle success
      htmltext.value = response.data.html
      IMGreplace(response.data.title)
      TOCreplace()
      Linkreplace("html")
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
}

function GetPostTOC()
{
  // Make a request for a post with a given ID
  axios
    .get('http://localhost:5000/Post/GetPostTOCById?id=' + id)
    .then(function (response)
    {
      // handle success
      var data = response.data

      document.getElementsByClassName('Catalog')[0].innerHTML = gen_catalog(data)
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
}

function IMGreplace(title: string)
{
  const regex: RegExp = new RegExp('<img src=".*img/(.*)" alt="(.*)" />', 'g')
  htmltext.value = htmltext.value.replaceAll(regex, '<img src="/src/assets/blogs/' + title + '/img/$1" alt="$2">')
}

function TOCreplace()
{
  const regex: RegExp = new RegExp('<p>\\[TOC]</p>', 'g')
  htmltext.value = htmltext.value.replace(regex, '')
}

function Linkreplace(type: string)
{
  // if (type == "html") {
  //   const regex: RegExp = new RegExp('<p>\\[TOC]</p>', 'g')
  //   htmltext.value = htmltext.value.replace(regex, '')
  // }
  // else {
  //   const regex: RegExp = new RegExp('<p>\\[TOC]</p>', 'g')
  //   htmltext.value = htmltext.value.replace(regex, '')
  // }
}

function gen_catalog(childs: any)
{
  var html = ''
  childs.forEach(el =>
  {
    html += `<details>
    <summary>
       <span class="catalog-item"><a href="${el.href}">${el.text}</a></span>
    </summary>`
    if (el.nodes && el.nodes.length) {
      html += gen_catalog(el.nodes) // 如果有chidren就继续遍历
    }
    html += `</details>`
  })
  return html;
}

</script>

<script lang="ts">
export default {
  data()
  {
    return {
      htmltext: '<h1></h1>'
    }
  }
}
</script>

<template>
  <div class="markdown-body" v-highlight v-html="htmltext" />
</template>

<style>
.markdown-body {
  background-color: white;
  box-sizing: border-box;
  min-width: 200px;
  max-width: 980px;
  margin: 0 auto;
  padding: 45px;
}
</style>
