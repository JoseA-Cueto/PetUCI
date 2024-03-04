<template>
  <!-- Modal -->
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Adoptar una Mascota</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="mb-3">
            <label for="nombre" class="form-label">Nombre del adoptante</label>
            <input type="text" class="form-control" id="nombre" v-model="nombre">
          </div>
          <div class="mb-3">
            <label for="apellidos" class="form-label">Apellidos del adoptante</label>
            <input type="text" class="form-control" id="apellidos" v-model="apellidos">
          </div>
          <div class="mb-3">
            <label for="direccion" class="form-label">Dirección</label>
            <input type="text" class="form-control" id="direccion" v-model="direccion">
          </div>
          <div class="mb-3">
            <label for="razon" class="form-label">Razón para adoptar</label>
            <textarea class="form-control" id="razon" rows="3" v-model="razon"></textarea>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
          <button type="button" class="btn btn-primary">Enviar Solicitud</button>
        </div>
      </div>
    </div>
  </div>

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
            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
              Adoptar!
            </button>
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
      loading: false,
      nombre: '',
      apellidos: '',
      direccion: '',
      razon: ''
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
        // Ocultar la barra de carga después de un pequeño retraso
        setTimeout(() => {
          this.loading = false;
        }, 500); // 500 milisegundos (0.5 segundos)
      }
    }
  }
}
</script>
<style>
body{
  background-image: url('../../assets/W2.jpg');
}
</style>