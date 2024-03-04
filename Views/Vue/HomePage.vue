<template>
<nav class="navbar navbar-light sticky-top" style="background-color: #e3f2fd;">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Bienvenido</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
      <div class="navbar-nav">
        <a class="nav-link active" aria-current="page" href="#about" >¿Quiénes Somos?</a>
        <a class="nav-link" href="#pets" >Mascotas</a>
        <a class="nav-link" href="#products">Productos</a>
        <button class="btn btn-secondary" data-bs-toggle="collapse" data-bs-target=".navbar-collapse.show"><i class="bi bi-caret-up-fill"></i></button>
      </div>
    </div>
  </div>
</nav>



   
    <div id="carouselExampleCaptions" class="carousel slide w-100 mx-auto"  data-bs-ride="carousel" >
      <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
      </div>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img src="../../assets/Banner_1.png" class="d-block w-100" style="height: 75%;" alt="">
          <div class="carousel-caption d-none d-md-block">
            <h5>First slide label</h5>
            <p>Some representative placeholder content for the first slide.</p>
          </div>
        </div>
        <div class="carousel-item">
          <img src="../../assets/Banner_2.png" class="d-block w-100" style="height: 75%;" alt="">
          <div class="carousel-caption d-none d-md-block">
            <h5>Second slide label</h5>
            <p>Some representative placeholder content for the second slide.</p>
          </div>
        </div>
        <div class="carousel-item">
          <img src="../../assets/Banner_3.png" class="d-block w-100" style="height: 75%;" alt="">
          <div class="carousel-caption d-none d-md-block">
            <h5>Third slide label</h5>
            <p>Some representative placeholder content for the third slide.</p>
          </div>
        </div>
      </div>
      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
    <section class="mt-5 mb-5 mb-5 pt-5 pb-5 " id="about">
      <h1 class="fs-1 text-center"> PetUCI</h1>
      <div class="d-flex justify-content-evenly align-items-center">
     
      <p class="p-3 mx-5">
      Petuci es una agencia dedicada al cuidado, protección y adopción de mascotas, 
      surgida como una iniciativa innovadora de la Universidad de las Ciencias Informáticas (UCI) 
      con el objetivo de abordar la problemática de las mascotas callejeras en el campus universitario
       y sus alrededores.

      La misión principal de Petuci es brindar un entorno seguro y amoroso 
      para los animales abandonados o perdidos, así como promover la conciencia sobre
      la responsabilidad de cuidar a las mascotas. La agencia trabaja en estrecha colaboración 
      on estudiantes, profesores, personal y la comunidad en general para asegurar el bienestar 
      de estos seres indefensos.
      </p>
      <img src="../../assets/2.png" class="img-fluid rounded-3 mx-5" >
    </div>
    </section>

    
    <section class="mt-5 mb-5 mb-5 pt-5 pb-5" id="pets"> 
  <h2 class="fs-1 text-center mt-3 mb-3">Animales disponibles para adopción</h2>
  <div id="carouselExampleInterval" class="carousel carousel-dark slide mx-auto" data-bs-ride="carousel">
    <div class="carousel-inner ">
      <div class="carousel-item active" data-bs-interval="10000">
        <div class="row">
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/Rocky.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Perro</h5>
                <p class="card-text">Nombre: Rocky <br> Sexo: Macho <br> Raza: Labrador Retriever</p>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/lunagata.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Gato</h5>
                <p class="card-text">Nombre: Luna <br> Sexo: Hembra <br> Raza: Siamés</p>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/Max.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Perro</h5>
                <p class="card-text">Nombre: Max <br> Sexo: Macho <br> Raza: Pastor Alemán</p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="carousel-item" data-bs-interval="10000">
        <div class="row">
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/simba.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Gato</h5>
                <p class="card-text">Nombre: Simba <br> Sexo: Macho <br> Raza: Persa</p>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/lunaperra.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Perro</h5>
                <p class="card-text">Nombre: Luna <br> Sexo: Hembra <br> Raza: Golden Retriever</p>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/thor.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Gato</h5>
                <p class="card-text">Nombre: Thor <br> Sexo: Macho <br> Raza: Bengalí</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleInterval" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleInterval" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>
</section>


    <section class="mt-5 mb-5 pt-5 pb-5" id="products"> 
  <h2 class="fs-1 text-center mt-3 mb-3">Productos destacados</h2>
  <div id="carouselProducts" class="carousel carousel-dark slide mx-auto" data-bs-ride="carousel">
    <div class="carousel-indicators ">
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
  </div>
    <div class="carousel-inner ">
      <div class="carousel-item active" data-bs-interval="10000">
        <div class="row">
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/alimentogato.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Delicioso alimento gourmet para gatos</h5>
                <p class="card-text">Mezcla especial de ingredientes nutritivos para una dieta balanceada.</p>
                <a href="#" class="btn btn-primary">Ver más</a>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/hamaca.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Cómoda hamaca para perros</h5>
                <p class="card-text">La hamaca perfecta para que tu perro descanse cómodamente.</p>
                <a href="#" class="btn btn-primary">Ver más</a>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/juguetegato.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Divertido juguete interactivo para gatos</h5>
                <p class="card-text">Mantén a tu gato entretenido durante horas con este juguete interactivo.</p>
                <a href="#" class="btn btn-primary">Ver más</a>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="carousel-item" data-bs-interval="10000">
        <div class="row">
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/golosinagato.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Deliciosa golosina para gatos</h5>
                <p class="card-text">Premia a tu gato con esta golosina irresistible.</p>
                <a href="#" class="btn btn-primary">Ver más</a>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/correa.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Correa de moda para paseos con tu perro</h5>
                <p class="card-text">Pasea a tu perro con estilo con esta correa moderna y resistente.</p>
                <a href="#" class="btn btn-primary">Ver más</a>
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="card" style="width: 18rem;">
              <img src="../../assets/morder.jpeg" class="card-img-top" alt="">
              <div class="card-body text-center">
                <h5 class="card-title">Juguete para morder y limpiar dientes de perros</h5>
                <p class="card-text">Ayuda a mantener los dientes de tu perro limpios y saludables con este juguete.</p>
                <a href="#" class="btn btn-primary">Ver más</a>
              </div>
            </div>
          </div>
        </div>
      </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselProducts" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselProducts" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
    </div>
   
  </div>
</section>


  </template>
  <style>
    body{
      background-image: url('../../assets/W2.jpg');
    }
</style>