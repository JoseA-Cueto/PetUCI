<template>
     <div class="container w-100">
      <h2 class="text-center mb-4">Administrar Productos</h2>
  
      <!-- Filtro de búsqueda -->
      <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Buscar producto..." v-model="searchTerm" @input="searchPets">
        <button class="btn btn-outline-secondary" type="button" @click="searchPets">Buscar</button>
      </div>
  
    
      <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#productModal">
         Agregar Producto
     </button>

<!-- Modal -->
<div class="modal fade" id="productModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Agregar Nuevo Producto</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <!-- Formulario para la creación de mascotas -->
        <form @submit.prevent="createProduct">
          <div class="mb-3">
            <label for="nombre" class="form-label">Nombre:</label>
            <input type="text" class="form-control" id="nombre" v-model="nombre" required>
          </div>
          <div class="mb-3">
            <label for="nombre" class="form-label">Cantidad:</label>
            <input type="text" class="form-control" id="cant" v-model="cant" required>
          </div>
        
          <div class="mb-3">
            <div class="mb-3">
            <label for="nombre" class="form-label">Descripción:</label>
            <input type="text" class="form-control" id="descp" v-model="descp" required>
          </div>
          </div>
          <div class="mb-3">
            <label for="raza" class="form-label">Precio:</label>
            <input type="text" class="form-control" id="preicio" v-model="preicio" required>
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
  
      <!-- Tabla de productos -->
      <table class="table table-striped table-hover">
      
        <thead class="text-center">
          <tr>
            <th scope="col">
              <button class="btn btn-dark">Imagen</button>
            </th>
            <th scope="col">
              <button class="btn btn-dark" @click="sortBy('nombre')">Nombre</button>
            </th>
            <th scope="col">
              <button class="btn btn-dark" @click="sortBy('cant')">Cantidad</button>
            </th>
            <th scope="col">
              <button class="btn btn-dark" @click="sortBy('precio')">Precio</button>
            </th>
            <th scope="col">Acciones</th>
          </tr>
        </thead>
  
       
        <tbody>
          <tr v-for="product in products" :key="product.id">
            <td class="align-middle text-center">
              <img :src="pet.ImagePath" :style="{ width: '120px' }" class="img-thumbnail border border-5" alt="">
            </td>
            <td class="align-middle text-center">{{ product.nombret }}</td>
            <td class="align-middle text-center">{{ product.cant  }}</td>
            <td class="align-middle text-center">{{ product.precio }}</td>
            <td class="align-middle text-center">
              <button class="btn btn-sm btn-dark" type="button" @click="showProductDetails(product.id)">
                <i class="bi bi-eye"></i> Detalles
              </button>
              <button class="btn btn-sm btn-danger" @click="deleteProduct(product.id)">
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
      searchTerm: '',
      products: [],
      loading: false,
      currentPage: 1,
      totalPages: 0,
      nombre: '',
      cant: '',
      descp: '',
      precio: '',
      imagen: null
    };
  },
  mounted() {
    this.fetchProducts();
  },
  methods: {
    async fetchProducts() {
      this.loading = true;
      try {
        const response = await fetch('../api/Product/GetAllProducts'); // Ruta de tu backend para obtener los productos
        const data = await response.json();
        this.products = products;
        this.totalPages = totalPages;
      } catch (error) {
        console.error('Error fetching products:', error);
      } finally {
        this.loading = false;
      }
    },
    async createProduct() {
      const formData = new FormData();
      formData.append('nombre', this.nombre);
      formData.append('cant', this.cant);
      formData.append('descp', this.descp);
      formData.append('precio', this.precio);
      formData.append('imagen', this.imagen);

      try {
        const response = await fetch('../api/Product/AddProduct', {
          method: 'POST',
          body: formData
        });

        if (response.ok) {
          console.log('Producto agregado exitosamente');
          this.nombre = '';
          this.cant = '';
          this.descp = '';
          this.precio = '';
          this.imagen = null;
          this.fetchProducts(); // Actualiza la lista de productos después de agregar uno nuevo
        } else {
          console.error('Error al agregar producto:', response.statusText);
        }
      } catch (error) {
        console.error('Error al agregar producto:', error);
      }
    },
    handleImageUpload(event) {
    
      this.imagen = event.target.files[0];
    },
    sortBy(key) {
      
    },
    showProductDetails(petId) {
    
    },
    deleteProduct(petId) {
      
    },
    goToPage(page) {
       
    },
    searchPeroduct() {

    }
  }
};
</script>


<style>

</style>