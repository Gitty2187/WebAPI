

function show() {
    const loginForm = document.getElementById('login');
    const registerForm = document.getElementById('register');
    if (loginForm.style.display === 'none') {
        loginForm.style.display = 'block';
        registerForm.style.display = 'none';
    } else {
        loginForm.style.display = 'none';
        registerForm.style.display = 'block';
    }
}

async function login() {
    const userName = document.getElementById("loginUserName").value;
    const password = document.getElementById("loginPassword").value;
    const userLogin = { UserName : userName, Password : password }
    try {
        const res = await fetch('api/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userLogin)
        });


        if (res.ok) {
            const data = await res.json();
            localStorage.setItem("UserId", data.id);
            localStorage.setItem("UserName", data.userName);
            localStorage.setItem("UserFirstName", data.firstName);
            localStorage.setItem("UserLastName", data.lastName)
            window.location.href = "hello.html";
        }
        else {
            switch (responsePost.status) {
                case 400:
                    const badRequestData = await responsePost.json();
                    alert(`Bad request: ${badRequestData.message || 'Invalid input. Please check your data.'}`);
                    break;
                case 401:
                    alert("Unauthorized: Please check your credentials.");
                    break;
                case 500:
                    alert("Server error. Please try again later.");
                    break;
                default:
                    alert(`Unexpected error: ${responsePost.status}`);
            }
        }
    }
    catch (e) {
        alert("Error: " + e.message);
        alert("Error: " + e.message);
    }
}

async function get() {
    try {
        const res = await fetch('api/users')
        if (!res.ok) {
            throw new Error('Network response was not ok');
        }

        alert('Get: ', res);
    } catch (error) {
        alert('There was a problem with the fetch operation get:', error);
    }
}

async function logup() {
    const UserName = document.getElementById("registerUserName").value;
    const Password = document.getElementById("registerPassword").value;
    const FirstName = document.getElementById("firstName").value;
    const LastName = document.getElementById("lastName").value;
    const user = { UserName, Password, FirstName, LastName };

    try
    {
        const res = await fetch('api/users', {
            method: 'POST',
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
            alert("משתמש נוסף בהצלחה")
        }
    }
    catch (error) {
        alert(error.text);
    }
}


async function chekPassword() {
    const password = document.getElementById("registerPassword").value;
    try {
        const res = await fetch(`api/users/checkPassword`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });

        if (res.ok) {
            const message = await res.text(); 
            alert(message);
        } else {
            alert("הסיסמה לא תקינה או שגיאה בשרת");
        }
    } catch {
        alert("שגיאה בתקשורת עם השרת");
    }

}





