<template>
    <section>
      <div v-for="(comment, index) in comments" :key="index" class="alert alert-primary mx-5" role="alert">
        {{ comment.text }}
      </div>
    </section>
    <div class="input-group mb-3">
      <input v-model="newComment" @keyup.enter="addComment" type="text" class="form-control" placeholder="Escribe tu comentario" aria-label="Escribe tu comentario" aria-describedby="button-addon2">
      <button @click="addComment" class="btn btn-outline-primary" type="button" id="button-addon2"><i class="bi bi-send"></i></button>
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
        comments: [],
        newComment: '',
        showCard: true

      };
    },
    mounted() {
    setTimeout(() => {
      this.showCard = false;
    }, 5000); // Mostrar la tarjeta durante 5 segundos
  },
    methods: {
      addComment() {
        if (this.newComment.trim() !== '') {
          this.comments.push({ text: this.newComment });
          this.newComment = '';
        }
      }
    }
  };
  </script>
  