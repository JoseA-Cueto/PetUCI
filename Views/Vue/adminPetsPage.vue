
<template>
    <div class="container w-100">
      <h2 class="text-center mb-4">Administrar Mascotas</h2>
  
      <!-- Filtro de búsqueda -->
      <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Buscar mascota..." v-model="searchTerm" @input="searchPets">
        <button class="btn btn-outline-secondary" type="button" @click="searchPets">Buscar</button>
      </div>
  
    
      <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Agregar Mascota
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Agregar Nueva Mascota</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <!-- Formulario para la creación de mascotas -->
        <form @submit.prevent="createPet">
          <div class="mb-3">
            <label for="nombre" class="form-label">Nombre:</label>
            <input type="text" class="form-control" id="nombre" v-model="nombre" required>
          </div>
          <div class="mb-3">
            <label for="sexo" class="form-label">Sexo:</label>
            <select class="form-select" id="sexo" v-model="sexo" required>
              <option value="macho">Macho</option>
              <option value="hembra">Hembra</option>
            </select>
          </div>
          <div class="mb-3">
            <label for="raza" class="form-label">Raza:</label>
            <input type="text" class="form-control" id="raza" v-model="raza" required>
          </div>
          <div class="mb-3">
            <label for="imagen" class="form-label">Imagen:</label>
            <input type="file" class="form-control" id="petImagen" @change="handleImageUpload" required>
          </div>
          <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
      </div>
    </div>
  </div>
</div>
  
      <!-- Tabla de mascotas -->
      <table class="table table-striped table-hover">
      
        <thead class="text-center">
          <tr>
            <th scope="col">
              <button class="btn btn-dark">Imagen</button>
            </th>
            <th scope="col">
              <button class="btn btn-dark" @click="sortBy('namePet')">Nombre</button>
            </th>
            <th scope="col">
              <button class="btn btn-dark" @click="sortBy('sexo')">Sexo</button>
            </th>
            <th scope="col">
              <button class="btn btn-dark" @click="sortBy('raza')">Raza</button>
            </th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
  
       
        <tbody>
          <tr v-for="pet in pets" :key="pet.id">
            <td class="align-middle text-center">
              <img :src="pet.ImagePath" :style="{ width: '120px' }" class="img-thumbnail border border-5" alt="">
            </td>
            <td class="align-middle text-center">{{ pet.namePet }}</td>
            <td class="align-middle text-center">{{ pet.sexo }}</td>
            <td class="align-middle text-center">{{ pet.raza }}</td>
            <td class="align-middle text-center">
              <button class="btn btn-sm btn-dark" type="button" @click="showPetDetails(pet.id)">
                <i class="bi bi-eye"></i> Detalles
              </button>
              <button class="btn btn-sm btn-danger" @click="deletePet(pet.id)">
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
      <nav>
        <ul class="pagination justify-content-end">
          <li class="page-item" :class="{ 'disabled': currentPage === 1 }">
            <button class="page-link" @click="goToPage(currentPage - 1)" :disabled="currentPage === 1">Anterior</button>
          </li>
          <li class="page-item" v-for="page in totalPages" :key="page" :class="{ 'active': page === currentPage }">
            <button class="page-link" @click="goToPage(page)">{{ page }}</button>
          </li>
          <li class="page-item" :class="{ 'disabled': currentPage === totalPages }">
            <button class="page-link" @click="goToPage(currentPage + 1)" :disabled="currentPage === totalPages">Siguiente</button>
          </li>
        </ul>
      </nav>
    </div>
  </template>


  <script>
  export default {
    data() {
      return {
        pets: [],
        loading: false,
        searchTerm: '',
        currentPage: 1,
        pageSize: 10,
        imagen: null,
        nombre: '',
        raza: '',
        sexo: ''
      };
    },
    computed: {
      paginatedPets() {
        const startIndex = (this.currentPage - 1) * this.pageSize;
        return this.pets.slice(startIndex, startIndex + this.pageSize);
      },
      totalPages() {
        return Math.ceil(this.pets.length / this.pageSize);
      }
    },
    mounted() {
      this.getAllPets();
    },
    methods: {
     
      async getAllPets() {
      
        this.loading = true; 
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
          
          setTimeout(() => {
            this.loading = false;
          }, 500); 
        }
      },
   
      async deletePet(id) {
      try {
        this.loading = true;
        const response = await fetch(`./api/Pet/DeletePet/${id}`, {
          method: 'DELETE',
        });
        if (!response.ok) {
          throw new Error('Error al eliminar la mascota');
        }
        this.pets = this.pets.filter(pet => pet.id !== id);
      } catch (error) {
        console.error('Error deleting pet:', error);
      } finally {
        this.loading = false;
      }
    },
   

      sortBy(field) {
      
      this.pets.sort((a, b) => (a[field] > b[field] ? 1 : -1));
    },
     showPetDetails(id) {
      
      
    },   async createPet() {
        const formData = new FormData();
        formData.append('nombre', this.nombre);
        formData.append('sexo', this.sexo);
        formData.append('raza', this.raza);
        formData.append('imagen', this.imagen);

        try {
          const response = await fetch('../api/Pet/AddPet', {
            method: 'POST',
            body: formData
          });

          if (response.ok) {
            // La petición fue exitosa
            console.log('Mascota agregada exitosamente');
            // Puedes hacer aquí alguna redirección o mostrar algún mensaje de éxito
          } else {
            // Hubo un error en la petición
            console.error('Error al agregar mascota:', response.statusText);
            // Muestra un mensaje de error al usuario si lo deseas
          }
        } catch (error) {
          console.error('Error al agregar mascota:', error);
          // Muestra un mensaje de error al usuario si lo deseas
        }
      },
      handleImageUpload(event) {
        // Al seleccionar una imagen en el input file, se guarda en this.imagen
        this.imagen = event.target.files[0];
      }
    }
  };
    
  
  </script>