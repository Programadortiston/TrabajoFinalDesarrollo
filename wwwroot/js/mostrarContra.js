var password = document.getElementById("password");

function mostrarPass() {
    if (password.type === "password") {
        password.type = "text";
    }
    else {
        password.type = "password";
    }
}