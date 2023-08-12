<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'

// Make a request for a user with a given ID
axios
  .get('http://localhost:5000/Post/GetPostsList')
  .then(function (response)
  {
    // handle success
    posts.value = response.data
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

const posts: any = ref(null)
</script>

// TODO:不使用elementUI
<template>
  <div class="Post" v-for="post in posts" :key="post.id">
    <div class="Post-header">
      <span>{{ post.title }}</span>
    </div>
    <div class="date">
      <span class="publish">发表于 </span>
      <span class="publish-date">{{ post.createTime.substring(0, 10) }}</span>
      <span> | </span>
      <span class="update">修改于 </span>
      <span class="update-date">{{ post.updateTime.substring(0, 10) }}</span>
    </div>
    <div class="catagory">
      <span>分类于 </span>
      <span class="catagoris">{{ post.categories }}</span>
    </div>
    <div class="Content">{{ post.summary }}</div>
    <RouterLink :to="'/post/' + post.id">
      <div class="button">阅读全文</div>
    </RouterLink>
  </div>
</template>

<style>
.Post {
  background-color: white;
  margin-bottom: 14px;
  /* color: black; */
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 40px;
  color: #999999;
}

.date {}

.Post-header {
  font-size: 26px;
  color: #555555;
  margin-bottom: 10px;
}

.publish-date .update-date {
  /* text-decoration: dotted; */
}

.catagory {
  margin-bottom: 10px;
}

.Content {
  font-size: 18px;
  color: black;
  line-height: 36px;
  margin-bottom: 20px;
}

.button {
  border: 1px solid black;
  padding: 8px 12px;
  font-size: 20px;
  color: black;
}

.button :hover {
  color: white;
  background-color: black;
}
</style>
