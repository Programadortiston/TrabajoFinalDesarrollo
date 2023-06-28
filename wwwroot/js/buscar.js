function buscar() {
    var input, filter, libros, contenedor, titulo, autor, stock, year, i;
    input = document.getElementById("buscar");
    filter = input.value.toUpperCase();
    contenedor = document.getElementById("buscar-libros");
    libros = contenedor.getElementsByClassName("contenedor");
    for (i = 0; i < libros.length; i++) {

        titulo = libros[i].querySelector(".libro-content h3.titulo");
        autor = libros[i].querySelector(".libro-content h3.autor");
        stock = libros[i].querySelector(".libro-content p.stock");
        year = libros[i].querySelector(".libro-content p.año");

        if (titulo.innerText.toUpperCase().indexOf(filter) > -1 ||
            autor.innerText.toUpperCase().indexOf(filter) > -1 ||
            stock.innerText.toUpperCase().indexOf(filter) > -1 ||
            year.innerText.toUpperCase().indexOf(filter) > -1) {
            libros[i].style.display = "";
        } else {
            libros[i].style.display = "none";
        }
    }
}
