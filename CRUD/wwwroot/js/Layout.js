//--------------------------------------------------------------------------------
// Animacion de descenso y aparicion de opciones
$(document).ready(function () {
    // Ocultar todas las sublistas al cargar la página
    $(".sub-menu-1").hide();

    // Mostrar u ocultar la sublista al hacer clic en el botón
    $(".toggle-button").click(function () {
        $(this).next(".sub-menu-1").slideToggle("slow");
    });
});

//--------------------------------------------------------------------------------
// Animacion de mensajes emergentes.
function showMessage(message, event) {
    // Remover cualquier mensaje emergente anterior
    hideMessage();

    // Crear un elemento de mensaje emergente
    var popup = document.createElement("div");
    popup.className = "popup";
    popup.textContent = message;

    // Posicionar el mensaje emergente cerca del puntero
    var mouseX = event.clientX;
    var mouseY = event.clientY;
    popup.style.left = mouseX + "px";
    popup.style.top = mouseY + "px";

    // Agregar el mensaje emergente al cuerpo del documento
    document.body.appendChild(popup);
}

function hideMessage() {
    // Remover cualquier mensaje emergente existente
    var popup = document.querySelector(".popup");
    if (popup) {
        document.body.removeChild(popup);
    }
}

//--------------------------------------------------------------------------------