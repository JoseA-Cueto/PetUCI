<template>
    <div class="row row-cols-1 row-cols-md-3 g-4">
      <div class="col" v-for="pet in pets" :key="pet.id">
        <div class="card">
          <img :src="pet.image" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{ pet.namePet }}</h5>
            <p class="card-text">{{ pet.sexo }}</p>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        pets: []
      };
    },
    mounted() {
      this.getAllPets();
    },
    methods: {
      async getAllPets() {
        try {
          const response = await fetch('./api/Pet/GetAllPets');
          if (!response.ok) {
            throw new Error('Error al obtener mascotas');
          }
          const pets = await response.json();
          this.pets = pets;
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
  