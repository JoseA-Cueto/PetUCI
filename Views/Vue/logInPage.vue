<template>
  <div class="login-container">
    <form @submit.prevent="submitForm" class="login-form">
      <fieldset>
        <legend>Iniciar sesión</legend>
        <div class="mb-3">
          <label for="username" class="form-label">Nombre de usuario</label>
          <input type="text" id="username" class="form-control" v-model="user.username" placeholder="Nombre de usuario" required>
        </div>
        <div class="mb-3">
          <label for="password" class="form-label">Contraseña</label>
          <input type="password" id="password" class="form-control" v-model="user.password" placeholder="Contraseña" required>
        </div>
        <button type="submit" class="btn btn-primary">Iniciar sesión</button>
      </fieldset>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      user: {
        username: '',
        password: ''
      }
    };
  },
  methods: {
    async submitForm() {
      try {
        const response = await fetch('./api/User/Validation', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(this.user)
        });

        if (response.ok) {
          const data = await response.json();
          // Guardar el token en localStorage
          localStorage.setItem('token', data.token);
          // Redireccionar al usuario a otra página después de iniciar sesión, por ejemplo, al panel de control
          window.location.href = '/dashboard';
        } else {
          console.error('Error al iniciar sesión:', response.status);
          // Manejar el error de inicio de sesión, por ejemplo, mostrar un mensaje de error al usuario
        }
      } catch (error) {
        console.error('Error al enviar solicitud:', error);
        // Manejar el error de red u otros errores
      }
    }
  }
}
</script>

<style>
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}

.login-form {
  width: 300px;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.2); /* Sombras paralelas */
}

.login-form fieldset {
  border: none;
}

.login-form legend {
  font-size: 1.2rem;
  font-weight: bold;
  margin-bottom: 20px;
}

.login-form button[type="submit"] {
  width: 100%;
}
</style>
