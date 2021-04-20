
/*
 *  This is the JS code for the order page
 *  It sets the CRUD methods for anything related to order
*/


// Set the variables
const uri = 'api/Orders'
let orders = [];
getItems();



// Function used by fetch to get all items
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => displayItems(data))
        .catch(error => console.error('Unable to get items.', error));

}

// POST -> function used to add an item
function addItem(e) {

    // basic validation
    if (document.myForm.loginName.value == "") {
        alert("Please provide your login name");
        document.myForm.loginName.focus();
        return false;
    }

    if (document.myForm.pizzaSelect.value == -1) {
        alert("Please make a pizza selection");
        document.myForm.pizzaSelect.focus();
        return false;
    }

    if (document.myForm.storeLocation.value == false) {
        alert("Please make a store selection");
        document.myForm.pizzaSelect.focus();
        return false;
    }

    
    // set the item to a variable
    const item = {
        customerId: 4,
        pizzaId:    document.myForm.pizzaSelect.value,
        storeId:    document.myForm.storeLocation.value
    }

    console.log(`Name: ${item.customerId}`);
    console.log(`Pizza: ${document.myForm.pizzaSelect.value}`);
    console.log(`Store: ${document.myForm.storeLocation.value}`);
    
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
            document.myForm.loginName.value = '';
        })
        .catch(error => console.error('Unable to add item.', error)
        );
}

function PrintSelection(pizzaSelection) {
    let para = document.createElement('p');
    paraNode = document.createTextNode(pizzaSelection);

    para.appendChild(paraNode);
    testDiv.appendChild(para);

}


// This is counter that is displayed to verify number of records
function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Order' : 'Orders';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}


// Displays items to the table element
function displayItems(data) {
    const tBody = document.getElementById('tBodyOrders');
    tBody.innerHTML = '';

    _displayCount(data.length);

    data.forEach(item => {

        let tr = tBody.insertRow();
        let tdName = tr.insertCell(0);
        let textNodeName = document.createTextNode(item.customerId);
        tdName.appendChild(textNodeName);

        let tdPizza = tr.insertCell(1);
        let textNodePizza = document.createTextNode(item.pizzaId);
        tdPizza.appendChild(textNodePizza);


        let tdStore = tr.insertCell(2);
        let textNodeStore = document.createTextNode(item.storeId);
        tdStore.appendChild(textNodeStore);

    });

    orders = data;

}




//const buttons = document.querySelectorAll("button");
//for (let i = 0; i < buttons.length; i++) {
//    buttons[i].addEventListener("click", addItem);
//}

//const loginForm = document.getElementById('loginForm');
//loginForm.addEventListener('submit', (event) => {
//    addItem();
//})
