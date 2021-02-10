document.addEventListener('DOMContentLoaded', function () {
    if ($('#admincontrols-menu').length > 0) {
        adminMenuToggle();
    }
})

function adminMenuToggle(){
    var dropdown = document.querySelector("#admincontrols-menu .dropdown-btn");
    dropdown.addEventListener("click", function () {
        $("i", this).toggleClass("fa-caret-down fa-caret-left");
        var dropdowncontent = document.querySelectorAll("#admincontrols-menu .dropdown-container");
        var i;
        for (i = 0; i < dropdowncontent.length; i++) {
            if (dropdowncontent[i].style.display === "block") {
                dropdowncontent[i].style.display = "none";
            } else {
                dropdowncontent[i].style.display = "block";
            }
        }
    });
}
