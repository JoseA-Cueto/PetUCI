<template>


    <div class="row row-cols-1 row-cols-md-3 g-4">
      <div class="col" v-for="product in products" :key="product.id">
        <div class="card">
          <img :src="product.imagenPath" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{ product.name }}</h5>
            <p class="card-text">{{ product.description }}</p>
            <p class="card-text">{{ product.price }}</p>
            <a href="#" class="btn btn-primary"><i class="bi bi-cart-plus"></i></a>
          </div>
        </div>
      </div>
    </div>
     <!-- Componente card en la esquina de la pantalla -->
     <div v-if="showCard" class="position-fixed top-0 start-0 p-3 " style="z-index: 1050;">
      <div class="card text-white bg-danger mb-3" style="max-width: 18rem;">
        
        <div class="card-header">Foro en Desarrollo</div>
        <div class="card-body">
            <img src="../../assets/workingOn.jpg" class="  card-img-top rounded mx-auto d-block" >
          <h5 class="card-title">Estamos trabajando en mejorar tu experiencia</h5>
          <p class="card-text">¡La función de foro estará disponible pronto!</p>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        showCard: true,
        products: [
      {
        name: "Delicioso alimento gourmet para gatos",
        price: 10.99,
        description: "La hamaca perfecta para que tu perro descanse cómodamente.",
        imagenPath: "../../assets/alimentogato.jpeg"
      },
      {
        name: "Cómoda hamaca para perros",
        price: 19.99,
        description: "La hamaca perfecta para que tu perro descanse cómodamente.",
        ImagePath: "../../assets/hamaca.jpeg"
      },
      {
        name: "Divertido juguete interactivo para gatos",
        price: 25.99,
        description: "Mantén a tu gato entretenido durante horas con este juguete interactivo.",
        ImagePath: "../../assets/juguetegato.jpeg"
      },
      {
        name: "Deliciosa golosina para gatos",
        price: 14.99,
        description: "Premia a tu gato con esta golosina irresistible.",
        ImagePath: "../../assets/golosinagato.jpeg"
      },
      {
        name: "Correa de moda para paseos con tu perro",
        price: 32.99,
        description: "Pasea a tu perro con estilo con esta correa moderna y resistente.",
        ImagePath: "../../assets/correa.jpeg"
      },
      {
        name: "Juguete para morder y limpiar dientes de perros",
        price: 8.99,
        description: "Ayuda a mantener los dientes de tu perro limpios y saludables con este juguete.",
        ImagePath: "../../assets/morder.jpeg"
      }
    ]
  };
      
    },
    mounted() {
      setTimeout(() => {
      this.showCard = false;
    }, 5000); // Mostrar la tarjeta durante 5 segundos
      //this.getAllProducts();
    },
    methods: {
      /*async getAllProducts() {
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
      }*/
    }
  }
  </script>
  
  <style>
  /* Estilos CSS según sea necesario */
  </style>
  
  