<template>
  <div>
    <div class="d-flex">
      <nav class="nav flex-column nav-pills me-3" id="v-pills-tab" role="tablist" aria-orientation="vertical">
        <button class="nav-link active pt-5 pb-5 mx-3" id="v-pills-mascotas-tab" data-bs-toggle="pill" data-bs-target="#v-pills-mascotas" type="button" role="tab" aria-controls="v-pills-mascotas" aria-selected="true">Mascotas</button>
        <button class="nav-link pt-5 pb-5 mx-3" id="v-pills-productos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-productos" type="button" role="tab" aria-controls="v-pills-productos" aria-selected="false">Productos</button>
        <button class="nav-link pt-5 pb-5 mx-3" id="v-pills-cursos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-cursos" type="button" role="tab" aria-controls="v-pills-cursos" aria-selected="false">Cursos</button>
        <button class="nav-link pt-5 pb-5 mx-3" id="v-pills-enfermedades-tab" data-bs-toggle="pill" data-bs-target="#v-pills-enfermedades" type="button" role="tab" aria-controls="v-pills-enfermedades" aria-selected="false">Enfermedades</button>
        <button class="nav-link pt-5 pb-5 mx-3" id="v-pills-vacunas-tab" data-bs-toggle="pill" data-bs-target="#v-pills-vacunas" type="button" role="tab" aria-controls="v-pills-vacunas" aria-selected="false">Vacunas</button>
        <button class="nav-link pt-5 pb-5 mx-3" id="v-pills-tratamientos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-tratamientos" type="button" role="tab" aria-controls="v-pills-tratamientos" aria-selected="false">Tratamientos</button>
      </nav>
      <div class="tab-content w-100 fluid " id="v-pills-tabContent">
        <div class="tab-pane fade show active " id="v-pills-mascotas" role="tabpanel" aria-labelledby="v-pills-mascotas-tab">
          <adminPetsPageVue></adminPetsPageVue>
        </div>
        <div class="tab-pane fade" id="v-pills-productos" role="tabpanel" aria-labelledby="v-pills-productos-tab">
          <adminProductPageVue></adminProductPageVue>
        </div>
        <div class="tab-pane fade" id="v-pills-cursos" role="tabpanel" aria-labelledby="v-pills-cursos-tab">
          <workingOnPageVue></workingOnPageVue>
        </div>
        <div class="tab-pane fade" id="v-pills-enfermedades" role="tabpanel" aria-labelledby="v-pills-enfermedades-tab">
          <adminDiseasePageVue></adminDiseasePageVue>
        </div>
        <div class="tab-pane fade" id="v-pills-vacunas" role="tabpanel" aria-labelledby="v-pills-vacunas-tab">
          <workingOnPageVue></workingOnPageVue>
        </div>
        <div class="tab-pane fade" id="v-pills-tratamientos" role="tabpanel" aria-labelledby="v-pills-tratamientos-tab">
          <workingOnPageVue></workingOnPageVue>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import adminPetsPageVue from './adminPetsPage.vue'
import adminProductPageVue from './adminProductPage.vue'
import adminDiseasePageVue from './adminDiseasePage.vue'
import workingOnPageVue from './workingOnPage.vue'

export default {
  components: {
    adminPetsPageVue,
    adminProductPageVue, 
    adminDiseasePageVue,
    workingOnPageVue
  }
}
</script>
