<template>
     <div>
      
      <h1 v-show="showMessage">{{ message }}</h1>
      <button @click="toggleVisibility" class="btn btn-primary">Toggle Visibility</button>

    </div>
</template>

<script>
   import '../lib/bootstrap/dist/css/bootstrap.css';
   import '../lib/bootstrap/dist/js/bootstrap.bundle.js';

  export default {
    data() {
      return {
        message: 'SIUUUUUUUUU',
        showMessage: true,
      };
    },
    methods: {
      toggleVisibility() {
        this.showMessage = !this.showMessage;
      },
    },
  };
  </script>