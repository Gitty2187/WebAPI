


window.onload = function () {
    const userName = localStorage.getItem("UserName");
    if (userName) {
        document.getElementById("name").innerHTML = userName;
        document.getElementById("firstName").value = userName;
    } else {
        document.getElementById("name").innerHTML = ""; 
    }
    const userLastName = localStorage.getItem("UserLastName");
    if (userLastName) {
        document.getElementById("lastName").value = userLastName;
    } else {
        document.getElementById("lastName").value = "";
    }
};




