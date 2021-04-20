﻿
/*
 *  This is the JS code for the store page
 *  It sets the CRUD methods for anything related to stores
*/

// Set the variables
const uri = 'api/Customers'
let people = [];
getItems();

// Function used by fetch to get all items
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => displayItems(data))
        .catch(error => console.error('Unable to get items.', error));

}

// POST -> function used to add an item
function addItem() {
    const nameTextBox = document.getElementById('loginName');


    // set the item to a variable
    const item = {
        name: nameTextBox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            nameTextBox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error)
        );
}


// This is counter that is displayed to verify number of records
function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Person' : 'People';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}


// Displays items to the table element
function displayItems(data) {
    const tBody = document.getElementById('tBodyPeople');
    tBody.innerHTML = '';

    _displayCount(data.length);

    data.forEach(item => {
        //let isAdminCheckBox = document.createElement('input');
        //isAdminCheckBox.type = 'checkBox';
        //isAdminCheckBox.disabled = true;
        //isAdminCheckBox.checked = item.isAdmin;


        let tr = tBody.insertRow();

        let tdName = tr.insertCell(0);
        let textNodeName = document.createTextNode(item.name);
        tdName.appendChild(textNodeName);

        //let tdAdmin = tr.insertCell(1);
        //let textNodeAdmin = document.createTextNode(item.isAdmin);
        //tdAdmin.appendChild(textNodeAdmin);

    });

    people = data;

}



//const loginForm = document.getElementById('loginForm');
//loginForm.addEventListener('submit', (event) => {
//    addItem();
//})
