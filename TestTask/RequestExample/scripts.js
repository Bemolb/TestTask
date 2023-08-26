document.addEventListener("DOMContentLoaded", function () {
    const usersTable = document.getElementById("usersTable");
    const userForm = document.getElementById("userForm");

    function fetchUsers() {

        fetch(`${document.getElementById("url").value}/UserStorage`)
            .then(response => response.json())
            .then(data => {
                const tbody = usersTable.querySelector("tbody");
                tbody.innerHTML = "";
                for (let id in data) {
                    const row = document.createElement("tr");
                    row.setAttribute('data-id', id);
                    row.innerHTML = `
                        <td>${id}</td>
                        <td>${data[id].firstName}</td>
                        <td>${data[id].lastName}</td>
                        <td>${data[id].age}</td>
                        <td>${data[id].email}</td>
                        <td>
                            <div class="action-buttons">
                                <button onclick="deleteUser('${id}')">Delete</button>
                                <button onclick="editUser('${id}')">Edit</button>
                            </div>
                        </td>
                    `;
                    tbody.appendChild(row);
                }
            });
    }

    userForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const formData = {
            FirstName: document.getElementById("firstName").value,
            LastName: document.getElementById("lastName").value,
            Age: parseInt(document.getElementById("age").value),
            Email: document.getElementById("email").value
        };

        fetch(`${document.getElementById("url").value}/UserStorage`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)
        })
            .then(() => {
                fetchUsers();
            });
    });

    window.deleteUser = function (id) {
        fetch(`${document.getElementById("url").value}/UserStorage?id=${id}`, {
            method: "DELETE"
        })
            .then(() => {
                fetchUsers();
            });
    }
    window.editUser = function (id) {
        const row = document.querySelector(`tr[data-id="${id}"]`);
        const cells = Array.from(row.children);
        const originalData = {
            firstName: cells[1].innerText,
            lastName: cells[2].innerText,
            age: cells[3].innerText,
            email: cells[4].innerText
        };

        cells[1].innerHTML = `<input type="text" value="${originalData.firstName}">`;
        cells[2].innerHTML = `<input type="text" value="${originalData.lastName}">`;
        cells[3].innerHTML = `<input type="number" value="${originalData.age}">`;
        cells[4].innerHTML = `<input type="email" value="${originalData.email}">`;

        cells[5].innerHTML = `
         <div class="action-buttons">
            <button onclick="saveUser('${id}')">Save</button>
            <button onclick="cancelEdit('${id}')">Cancel</button>
        </div>
    `;
    }

    window.saveUser = function (id) {
        const row = document.querySelector(`tr[data-id="${id}"]`);
        const formData = {
            FirstName: row.querySelector(`td:nth-child(2) input`).value,
            LastName: row.querySelector(`td:nth-child(3) input`).value,
            Age: parseInt(row.querySelector(`td:nth-child(4) input`).value),
            Email: row.querySelector(`td:nth-child(5) input`).value
        };

        fetch(`${document.getElementById("url").value}/UserStorage?id=${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)
        })
            .then(() => {
                fetchUsers();
            });
    }

    window.cancelEdit = function (id) {
        fetchUsers();
    }
    fetchUsers();
});
