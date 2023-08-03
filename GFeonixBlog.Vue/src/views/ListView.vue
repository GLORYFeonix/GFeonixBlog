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

<template>
  <el-container>
    <el-main style="padding: 0">
      <el-card v-for="post in posts" :key="post.id" class="box-card" shadow="always">
        <template #header>
          <div class="card-header">
            <span>{{ post.title }}</span>
          </div>
        </template>
        <div class="text item">
          <span>{{ post.summary }}</span>
        </div>
        <RouterLink :to="'/post/' + post.id">
          <el-button class="button">查看全文</el-button>
        </RouterLink>
      </el-card>
    </el-main>
  </el-container>
</template>

<style>
.page-header {
  font-size: 30px;
  margin-top: 10px;
  margin-left: 30px;
  padding: 0px;
}

.card-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.text {
  font-size: 14px;
}

.item {
  margin-bottom: 18px;
}

.box-card {
  width: 100%;
  margin-bottom: 10px;
}</style>
