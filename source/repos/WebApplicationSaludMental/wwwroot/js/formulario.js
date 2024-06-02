document.addEventListener("DOMContentLoaded", function () {
    var switchBtn = document.getElementById("btn-switch");
    var form = document.querySelector(".contact-form form");
    var camposFormulario = form.querySelectorAll("input, select");

    switchBtn.addEventListener("change", function () {
        if (switchBtn.checked) {
            // Si el interruptor está activado, deshabilitar todos los campos excepto el campo de mensaje
            camposFormulario.forEach(function (element) {
                if (element.name !== "Mensaje") {
                    if (element.tagName === "INPUT" && element.type === "date") {
                        // Establecer fecha en la fecha actual
                        var today = new Date().toISOString().slice(0, 10);
                        element.value = today;
                    } else {
                        element.value = "Anonimo";
                    }
                    element.disabled = true;
                }
            });
        } else {
            // Si el interruptor está desactivado, habilitar todos los campos y limpiar los valores
            camposFormulario.forEach(function (element) {
                element.disabled = false;
                element.value = "";
            });
        }
    });
});