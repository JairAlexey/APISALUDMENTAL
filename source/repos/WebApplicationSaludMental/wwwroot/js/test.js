// Estructura de datos para manejar los cuestionarios
let cuestionarios = {
    MiedoInseguridadesNinos: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, nivel bajo de ansiedad escolar." },
            { max: 14, mensaje: "Bien, algunas preocupaciones pueden necesitar atención." },
            { max: 19, mensaje: "Regular, considera buscar apoyo para manejar tus preocupaciones." },
            { max: 20, mensaje: "Alto nivel de ansiedad escolar, te recomendamos buscar ayuda profesional." }
        ]
    },
    MiedoInseguridadesJovenes: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, nivel bajo de ansiedad escolar." },
            { max: 14, mensaje: "Bien, algunas preocupaciones pueden necesitar atención." },
            { max: 19, mensaje: "Regular, considera buscar apoyo para manejar tus preocupaciones." },
            { max: 20, mensaje: "Alto nivel de ansiedad escolar, te recomendamos buscar ayuda profesional." }
        ]
    },
    EstadoAnimoNinos: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, estado de ánimo positivo y saludable." },
            { max: 14, mensaje: "Bien, algunas áreas podrían necesitar atención." },
            { max: 19, mensaje: "Regular, considera buscar apoyo para mejorar tu bienestar emocional." },
            { max: 20, mensaje: "Podrías estar experimentando dificultades significativas en tu estado de ánimo. Te recomendamos buscar ayuda profesional." }
        ]
    },
    EstadoAnimoJovenes: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, estado de ánimo positivo y saludable." },
            { max: 14, mensaje: "Bien, algunas áreas podrían necesitar atención." },
            { max: 19, mensaje: "Regular, considera buscar apoyo para mejorar tu bienestar emocional." },
            { max: 20, mensaje: "Podrías estar experimentando dificultades significativas en tu estado de ánimo. Te recomendamos buscar ayuda profesional." }
        ]
    },
    FelicidadNinos: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, alto nivel de bienestar emocional." },
            { max: 14, mensaje: "Bien, algunas áreas pueden necesitar atención." },
            { max: 19, mensaje: "Regular, considera buscar apoyo para mejorar tu bienestar emocional." },
            { max: 20, mensaje: "Bajo nivel de bienestar emocional, te recomendamos buscar ayuda profesional." }
        ]
    },
    FelicidadJovenes: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, alto nivel de bienestar emocional." },
            { max: 14, mensaje: "Bien, algunas áreas pueden necesitar atención." },
            { max: 19, mensaje: "Regular, considera buscar apoyo para mejorar tu bienestar emocional." },
            { max: 20, mensaje: "Bajo nivel de bienestar emocional, te recomendamos buscar ayuda profesional." }
        ]
    },
    ResponsabilidadNinos: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, alto nivel de responsabilidad y compromiso." },
            { max: 14, mensaje: "Bien, algunas áreas pueden necesitar atención." },
            { max: 19, mensaje: "Regular, considera mejorar tu nivel de responsabilidad y compromiso." },
            { max: 20, mensaje: "Bajo nivel de responsabilidad y compromiso, es importante trabajar en mejorar estas áreas." }
        ]
    },
    ResponsabilidadJovenes: {
        puntuaciones: [
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 }, { si: 2, no: 0 },
            { si: 2, no: 0 }, { si: 2, no: 0 }
        ],
        rangos: [
            { max: 9, mensaje: "Excelente, alto nivel de responsabilidad y compromiso." },
            { max: 14, mensaje: "Bien, algunas áreas pueden necesitar atención." },
            { max: 19, mensaje: "Regular, considera mejorar tu nivel de responsabilidad y compromiso." },
            { max: 20, mensaje: "Bajo nivel de responsabilidad y compromiso, es importante trabajar en mejorar estas áreas." }
        ]
    }

};

// Array para almacenar las opciones elegidas
let opcion_elegida = [];

// Función para manejar la respuesta seleccionada
function respuesta(num_pregunta, seleccionada) {
    // Obtener el cuestionarioId directamente del <body>
    const cuestionarioId = document.body.getAttribute('data-cuestionario-id');
    opcion_elegida[num_pregunta] = seleccionada.value;

    let id = "p" + num_pregunta;
    let labels = document.getElementById(id).querySelectorAll("label");
    labels.forEach(label => label.style.backgroundColor = "white");

    seleccionada.parentNode.style.backgroundColor = "#cec0fc";
}

// Función para calcular el mensaje basado en la puntuación total
function calcularMensaje(cuestionarioId, totalPuntos) {
    let cuestionario = cuestionarios[cuestionarioId];
    let mensajeNivel = "";

    for (let rango of cuestionario.rangos) {
        if (totalPuntos <= rango.max) {
            mensajeNivel = rango.mensaje;
            break; // Salimos del bucle una vez encontrado el rango correcto
        }
    }

    return mensajeNivel;
}

// Función para revelar los resultados del cuestionario
function revelar() {
    // Obtener el cuestionarioId directamente del <body>
    const cuestionarioId = document.body.getAttribute('data-cuestionario-id');
    let puntuaciones = cuestionarios[cuestionarioId].puntuaciones;
    let resultadoHTML = "";
    let totalPuntos = 0;

    for (let i = 0; i < puntuaciones.length; i++) {
        let puntos = opcion_elegida[i] === "1" ? puntuaciones[i].si : puntuaciones[i].no;
        totalPuntos += puntos;
    }

    let mensajeNivel = calcularMensaje(cuestionarioId, totalPuntos);
    resultadoHTML += `<p>Total de puntos: ${totalPuntos}</p>`;
    resultadoHTML += `<p>${mensajeNivel}</p>`;
    document.getElementById("resultado").innerHTML = resultadoHTML;
}