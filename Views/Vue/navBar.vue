<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <div class="container-fluid">
    <router-link class="navbar-brand"  to="/">PetUCI</router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavPrincipal" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavPrincipal">
      <div class="navbar-nav">
        <a class="nav-link active" aria-current="page" href="#about">¿Quienes Somos?</a>
        <router-link class="nav-link" to="/pet">Mascotas</router-link>
        <router-link class="nav-link" to="/product">Productos</router-link>
        <router-link class="nav-link" to="/forum">Foro</router-link>
        <router-link class="nav-link" to="/login">Iniciar Sesión</router-link>
      </div>
    </div>
  </div>
</nav>
</template>