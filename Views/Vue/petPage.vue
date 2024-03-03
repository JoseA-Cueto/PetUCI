<template>
  <div class="container-fluid">
    <div class="row justify-content-center mt-5">
      <div v-if="loading" class="progress" style="width: 18rem;">
        <div class="progress-bar" role="progressbar" aria-valuemin="0" aria-valuemax="100"></div>
      </div>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">
      <div class="col" v-for="pet in pets" :key="pet.id">
        <div class="card" style="width: 18rem;">
          <img src="../../assets/3.png" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{ pet.namePet }}</h5>
            <p class="card-text">{{ pet.sexo }}</p>
            <p class="card-text">{{ pet.raza }}</p>
            <button class="btn btn-primary">Adoptar</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      pets: [],
      loading: false
    };
  },
  mounted() {
    this.getAllPets();
  },
  methods: {
    async getAllPets() {
      this.loading = true; // Mostrar la barra de carga
      try {
        const response = await fetch('./api/Pet/GetAllPets');
        if (!response.ok) {
          throw new Error('Error al obtener mascotas');
        }
        const pets = await response.json();
        this.pets = pets;
      } catch (error) {
        console.error(error);
      } finally {
        this.loading = false; // Ocultar la barra de carga
      }
    }
  }
}
</script>

<style>
/* Estilos CSS según sea necesario */
</style>
