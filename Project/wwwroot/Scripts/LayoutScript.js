$(document).ready(function () {

    var Path = window.location.pathname;
    // 1. "/"
    // 2. "/Home/CatalogShow"
    // 3. "/Home/AdministratorShow"
    // 4. "/Home/AddNewAnimalShow"
    // 5. "/Home/EditScreenShow/?"
    // 6. "/Home/DisplayAnimal/?"

    switch (Path) {
        case "/Home/CatalogShow":
            $('#CatalogARef').addClass("active");
            break;
        case "/Home/AdministratorShow":
            $('#AdministratorARef').addClass("active");
            break;
        default:
            $('#HomeARef').addClass("active");
            break;
    }
});