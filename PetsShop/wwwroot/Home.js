

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
    try {
        const res = await fetch('api/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // תיקון השם לכותרת
            },
            body: JSON.stringify([userName, password])
        });


        if (res.ok) {
            const data = await res.json();
            localStorage.setItem("UserId", data.id);
            localStorage.setItem("UserName", data.firstName);
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
    const userName = document.getElementById("registerUserName").value;
    const password = document.getElementById("registerPassword").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const user = { userName, password, firstName, lastName };
    try {
        const res = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (!res.ok) {
            throw new Error('Network response was not ok');
        }
        alert("משתמש נוסף בהצלחה")
    } catch (error) {
        alert('There was a problem with the fetch operation:', error.message);
    }
}





