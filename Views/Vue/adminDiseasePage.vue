<template>
    <div class="container w-100">
      <h2 class="text-center mb-4">Administrar Enfermedades</h2>
    
      <!-- Filtro de búsqueda -->
      <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Buscar enfermedad..." v-model="searchTerm" @input="searchDiseases">
        <button class="btn btn-outline-secondary" type="button" @click="searchDiseases">Buscar</button>
      </div>
    
      <!-- Botón para agregar enfermedad -->
      <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#diseaseModal">
        Agregar Enfermedad
      </button>
  
      <!-- Modal para agregar nueva enfermedad -->
      <div class="modal fade" id="diseaseModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">Agregar Nueva Enfermedad</h5>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <!-- Formulario para la creación de enfermedades -->
              <form @submit.prevent="createDisease">
                <div class="mb-3">
                  <label for="nombre" class="form-label">Nombre:</label>
                  <input type="text" class="form-control" id="nombre" v-model="nombre" required>
                </div>
                <!-- Puedes agregar más campos según sea necesario para la enfermedad -->
                <button type="submit" class="btn btn-primary">Guardar</button>
              </form>
            </div>
          </div>
        </div>
      </div>
    
      <!-- Tabla de enfermedades -->
      <table class="table table-striped table-hover">
        <thead class="text-center">
          <tr>
            <th scope="col">Nombre</th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="disease in diseases" :key="disease.id">
            <td class="align-middle text-center">{{ disease.nombre }}</td>
            <td class="align-middle text-center">
              <button class="btn btn-sm btn-dark" @click="showDiseaseDetails(disease.id)">
                <i class="bi bi-eye"></i> Detalles
              </button>
              <button class="btn btn-sm btn-danger" @click="deleteDisease(disease.id)">
                <i class="bi bi-trash-fill"></i> Eliminar
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    
      <!-- Barra de carga -->
      <div class="progress" v-if="loading">
        <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" :style="{ width: '100%' }"></div>
      </div>
    
      <!-- Paginación -->
      <!-- Si se necesita paginación, puedes agregarla aquí -->
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        searchTerm: '',
        diseases: [],
        loading: false,
        nombre: ''
      };
    },
    mounted() {
      this.fetchDiseases();
    },
    methods: {
      async fetchDiseases() {
        this.loading = true;
        try {
          
          const response = await fetch('../api/Disease/GetAllDiseases');
          const data = await response.json();
          this.diseases = data.diseases;
        } catch (error) {
          console.error('Error fetching diseases:', error);
        } finally {
          this.loading = false;
        }
      },
      async createDisease() {
        try {
          
          const response = await fetch('../api/Disease/AddDisease"', {
            method: 'POST',
           headers: {
              'Content-Type': 'application/json'
         },
            body: JSON.stringify({ nombre: this.nombre })
          });
          if (response.ok) {
            console.log('Disease added successfully');
            this.nombre = '';
            this.fetchDiseases(); // Actualiza la lista de enfermedades después de agregar una nueva
          } else {
            console.error('Error adding disease:', response.statusText);
          }
        } catch (error) {
          console.error('Error adding disease:', error);
        }
      },
      showDiseaseDetails(diseaseId) {
        // Implementa lógica para mostrar los detalles de una enfermedad si es necesario
      },
      deleteDisease(diseaseId) {
        // Implementa lógica para eliminar una enfermedad si es necesario
      },
      searchDiseases() {
        // Implementa lógica para buscar enfermedades si es necesario
      }
    }
  };
  </script>
  