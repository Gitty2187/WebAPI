


window.onload = function () {
    const userName = localStorage.getItem("UserName");
    if (userName) {
        document.getElementById("userName1").value = userName;
    }
    const userLastName = localStorage.getItem("UserLastName");
    if (userLastName) 
        document.getElementById("lastName").value = userLastName;
    const firstName = localStorage.getItem("UserFirstName");
    if (firstName) {
        document.getElementById("firstName").value = firstName;
        document.getElementById("name").value = firstName;
    }
    
}

async function update() {
    const userName = document.getElementById("userName").value;
    const password = document.getElementById("password").value;
    //if (password == null) {
    //    password = localStorage.getItem("")
    //}
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const user = { userName, password, firstName, lastName };
    const id = localStorage.UserId;
    try {
        const res = await fetch(`api/users/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (!res.ok) {
            throw new Error('Network response was not ok');
        }
        localStorage.setItem("UserName", userName);
        localStorage.setItem("UserLastName", lastName)
        localStorage.setItem("UserFirstName", firstName)
        alert("משתמש עודכן בהצלחה")
    } catch (error) {
        alert('There was a problem with the fetch operation:', error.message);
    }

}







