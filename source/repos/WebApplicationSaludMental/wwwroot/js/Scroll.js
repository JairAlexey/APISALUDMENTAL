// Función para desplazar la página hacia arriba
function scrollToTop() {
    window.scrollTo(0, 0);
}


// Agregar evento al botón para que funcione al hacer clic
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('button-up').addEventListener('click', scrollToTop);
});
