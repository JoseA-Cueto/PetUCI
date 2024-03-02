<template>
    <div class="row row-cols-1 row-cols-md-3 g-4">
      <div class="col" v-for="product in products" :key="product.id">
        <div class="card">
          <img :src="product.ImagePath" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{ product.name }}</h5>
            <p class="card-text">{{ product.description }}</p>
            <p class="card-text">{{ product.price }}</p>
            <a href="#" class="btn btn-primary"><i class="bi bi-cart-plus"></i></a>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        products: []
      };
    },
    mounted() {
      this.getAllProducts();
    },
    methods: {
      async getAllProducts() {
        try {
          const response = await fetch('./api/Product/GetAllProducts');
          if (!response.ok) {
            throw new Error('Error al obtener productos');
          }
          const products = await response.json();
          this.products = products;
        } catch (error) {
          console.error(error);
        }
      }
    }
  }
  </script>
  
  <style>
  /* Estilos CSS según sea necesario */
  </style>
  
  