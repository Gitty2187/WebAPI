

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

        if (!res.ok) {
            throw new Error(res);
        }

        const data = await res.json();
        alert(JSON.stringify(res));
    }
    catch (e) {
        alert(e.message);
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
    const userName = document.getElementById("loginUserName").value;
    const password = document.getElementById("loginPassword").value;
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

        const data = await res.json();
        alert('User added:', data);
    } catch (error) {
        alert('There was a problem with the fetch operation:', error.message);
    }
}



