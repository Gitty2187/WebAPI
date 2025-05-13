


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
    const ID = localStorage.UserId;
    const UserName = document.getElementById("userName1").value;
    const Password = document.getElementById("password").value;
    const FirstName = document.getElementById("firstName").value;
    const LastName = document.getElementById("lastName").value;
    const user = { UserName, Password, FirstName, LastName, ID };
    
    try {
        const res = await fetch(`api/users/${ID}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (!res.ok) {
            const message = await res.text();
            alert(message);
        }
        else {

            localStorage.setItem("UserName", UserName);
            localStorage.setItem("UserLastName", LastName)
            localStorage.setItem("UserFirstName", FirstName)
            alert("משתמש עודכן בהצלחה")
        }
    } catch (error) {
        alert(error.message);
    }

}







